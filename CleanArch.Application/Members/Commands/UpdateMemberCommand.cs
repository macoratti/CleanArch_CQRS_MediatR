using CleanArch.Domain.Abstractions;
using CleanArch.Domain.Entities;
using MediatR;

namespace CleanArch.Application.Members.Commands;

public sealed class UpdateMemberCommand : MemberCommandBase
{
    public int Id { get; set; }
    public class UpdateMemberCommandHandler :
                 IRequestHandler<UpdateMemberCommand, Member>
    {
        private readonly IUnitOfWork _unitOfWork;
        public UpdateMemberCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Member> Handle(UpdateMemberCommand request, CancellationToken cancellationToken)
        {
            var existingMember = await _unitOfWork.MemberRepository.GetMemberById(request.Id);

            if (existingMember is null)
                throw new InvalidOperationException("Member not found");

            existingMember.Update(request.FirstName, request.LastName, request.Gender, request.Email, request.IsActive);
            _unitOfWork.MemberRepository.UpdateMember(existingMember);
            await _unitOfWork.CommitAsync();

            return existingMember;
        }
    }
}
