using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Data.Entity;
using System.Data.Objects;
using System.Linq;
using System.Linq.Expressions;

using CHAI.LISDashboard.CoreDomain.Admins;
using CHAI.LISDashboard.CoreDomain.Users;
using CHAI.LISDashboard.CoreDomain.DataAccess;
using CHAI.LISDashboard.CoreDomain.Infrastructure;
using CHAI.LISDashboard.CoreDomain;
using System.Data.SqlClient;
using System.Data;
using System.Data.Common;

namespace CHAI.LISDashboard.Services
{
    public class AdminServices
    {
        public AdminServices()
        {
        }

        private IEnumerable<AppUser> _users;
        public IEnumerable<AppUser> GetAllUsers { get { return _users ?? (_users = Dao.Query<AppUser>(x => x.AppUserRoles)); } }

        public AppUser GetUserByUserName(string username)
        {
            return  GetAllUsers.Single(x => x.UserName == username);
        }
                
        public IEnumerable<AppUser> SearchUsers(string username)
        {
            
            return Dao.Query<AppUser>(x => x.UserName.StartsWith(username));
        }

        private IEnumerable<Node> _nodes;
        public IEnumerable<Node> GetAllNodes { get { return _nodes ?? (_nodes = Dao.Query<Node>(x => x.NodeRoles.Select(y => y.Role))); } }

        public Node ActiveNode(string pageid)
        {
            return Dao.Single<Node>(x => x.PageId == pageid, x => x.NodeRoles.Select(y => y.Role));
        }
        
        public void MoveTabUp(Tab tab)
        {
            UpdateTabPosition(tab.Id, 1);
        }

        public void MoveTabDown(Tab tab)
        {
            UpdateTabPosition(tab.Id, 2);
        }
        public void MoveUpTaskPan(int panid)
        {
            UpdateTaskpanPosition(panid, 1);
        }

        public void MoveDownTaskPan(int panid)
        {
            UpdateTaskpanPosition(panid, 2);
        }
        public void MoveUpPanNode(int id)
        {
            UpdateTaskpanNodePosition(id,1);
        }
        public void MoveDownPanNode(int id)
        {
            UpdateTaskpanNodePosition(id,2);
        }

        public int GetMaxTabPosition()
        {
            int? val = Dao.Select<Tab, int?>(x => x.Position, null).Max();

           if (val.HasValue)
               return val.Value + 1;

           return 1;
        }

        private void UpdateTabPosition(int tabId, int direction)
        {
            var tabIdParameter = new SqlParameter("TabId", tabId);
            var directionParameter = new SqlParameter("Direction", direction);

            Dao.ExecuteFunction("UpdateTabPosition", tabIdParameter, directionParameter);
        }

        private void UpdateTaskpanNodePosition(int panNodeId, int direction)
        {
            
            var parameters = new SqlParameter[]
                { 
                    new SqlParameter("@PanNodeId", SqlDbType.Int),
                    new SqlParameter("@Direction", SqlDbType.Int)
                };

            parameters[0].Value = panNodeId;
            parameters[1].Value = direction;
           // var panNodeIdParameter = new SqlParameter("@PanNodeId", panNodeId);
           // var directionParameter = new SqlParameter("@Direction", direction);

            Dao.ExecuteFunction("UpdateTaskpanNodePosition", parameters);
        }

        private void UpdateTaskpanPosition(int panId, int direction)
        {
            var panIdParameter = new SqlParameter("PanId", panId);
            var directionParameter = new SqlParameter("Direction", direction);

            Dao.ExecuteFunction("UpdateTaskpanPosition", panIdParameter, directionParameter);
        }

    }
}
