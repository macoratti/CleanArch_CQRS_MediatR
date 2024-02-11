using CleanArch.Domain.Entities;

namespace CleanArch.Domain.Abstractions;

public interface IMemberDapperRepository
{
    Task<IEnumerable<Member>> GetMembers();
    Task<Member> GetMemberById(int id);
}
