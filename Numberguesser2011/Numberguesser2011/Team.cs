using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Numberguesser2011
{
    class Team
    {
        public Character[] _members;
        Character _leader = null;
        bool _isDead = false;


        public String TeamName
        {
            get;
            protected set;
        }

        public Character[] Members
        {
            get { return _members; }
        }

        public Character Leader
        {
            get { return _leader; }
        }

        public bool IsDead
        {
            get { return _isDead; }
            set { _isDead = value; }
        }


        public void SetTeam(Character[] members, Character leader)
        {
            _members = members;
            _leader = leader;
            bool validLeader = false;
            for (int i = 0; i < _members.Length; i++)
                if (_members[i] == _leader)
                    validLeader = true;
            if (!validLeader)
                throw new InvalidOperationException();
            this.TeamName = _leader.Name;
            for (int i = 0; i < _members.Length; i++)
                _members[i].Team = this;
        }


        public void SetTeam(Character[] members, int leaderIndex)
        {
            SetTeam(members, members[leaderIndex]);
        }


        public void SetTeam(Character[] members)
        {
            SetTeam(members, members[0]);
        }
    }
}
