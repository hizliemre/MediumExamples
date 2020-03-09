using System.Collections.Generic;

namespace MediumTest
{
    public class MembersContainer
    {
        private readonly List<int> _members;
        public MembersContainer()
        {
            _members = new List<int>();
        }

        public int Count => _members.Count;

        public List<int> Items => _members;

        public void Add(int member) => _members.Add(member);
    }
}
