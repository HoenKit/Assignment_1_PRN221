using Assignment1_PRN221_Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1_PRN221_Library.IRepository
{
    public interface IMemberRepository
    {
        public void AddMember (Member member);
        public void UpdateMember (Member member);
        public void DeleteMember (Member member);
        public Member GetMember (int id);
        public IEnumerable<Member> GetAllMembers ();
        public Member Login (string email, string password);
        public bool IsEmailExists(string email);
    }
}
