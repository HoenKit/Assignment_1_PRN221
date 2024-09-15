using Assignment1_PRN221_Library.IRepository;
using Assignment1_PRN221_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1_PRN221_Library.Repository
{
    public class MemberRepository : IMemberRepository
    {
        private readonly DataContext _context;
        public MemberRepository(DataContext context)
        {
            _context = context;
        }
        public void AddMember(Member member)
        {
            _context.Members.Add(member);
            _context.SaveChanges();
        }

        public void DeleteMember(Member member)
        {
            var member1 = GetMember(member.MemberId);
            _context.Remove(member1);
            _context.SaveChanges();
        }

        public IEnumerable<Member> GetAllMembers() => _context.Members.ToList();

        public Member GetMember(int id) => _context.Members.Where(m => m.MemberId == id).FirstOrDefault();

        public Member Login(string email, string password)
        {
            var member = _context.Members.Where(m => m.Email == email && m.Password == password).FirstOrDefault();
            return member;
        }

        public void UpdateMember(Member member)
        {
            var member1 = GetMember(member.MemberId);
            member1.CompanyName = member.CompanyName;
            member1.Email = member.Email;
            member1.Password = member.Password;
            member1.City = member.City;
            member1.Country = member.Country;
            _context.Update(member1);
            _context.SaveChanges();
        }
        public bool IsEmailExists(string email) => _context.Members.Any(m => m.Email == email);
    }
}
