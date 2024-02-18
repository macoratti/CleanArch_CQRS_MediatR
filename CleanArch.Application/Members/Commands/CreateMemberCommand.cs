using CleanArch.Domain.Abstractions;
using CleanArch.Domain.Entities;
using FluentValidation;
using MediatR;
namespace CleanArch.Application.Members.Commands;
public class CreateMemberCommand : MemberCommandBase
{
    public class CreateMemberCommandHandler : IRequestHandler<CreateMemberCommand, Member>
    {
        private readonly IUnitOfWork _unitOfWork;
        //private readonly IValidator<CreateMemberCommand> _validator;
        public CreateMemberCommandHandler(IUnitOfWork unitOfWork) //IValidator<CreateMemberCommand> validator)
        {
            _unitOfWork = unitOfWork;
            //_validator = validator;
        }
        public async Task<Member> Handle(CreateMemberCommand request, CancellationToken cancellationToken)
        {
            //_validator.ValidateAndThrow(request);

            var newMember = new Member(request.FirstName, request.LastName, request.Gender, request.Email, request.IsActive);

            await _unitOfWork.MemberRepository.AddMember(newMember);
            await _unitOfWork.CommitAsync();

            return newMember;
        }
    }

}
