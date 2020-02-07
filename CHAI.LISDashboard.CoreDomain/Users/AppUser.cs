
using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Principal;
using CHAI.LISDashboard.Enums;
using CHAI.LISDashboard.Shared;
using CHAI.LISDashboard.CoreDomain.Admins;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;


namespace CHAI.LISDashboard.CoreDomain.Users
{
    [Table("AppUsers", Schema = "dbo")]
    public partial class AppUser : IEntity, IIdentity
    {
        public AppUser()
        {
            this._appUserRole = new List<AppUserRole>();
            this.UserLocations = new List<UserLocation>();
            
        }
        
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
        public Nullable<System.DateTime> LastLogin { get; set; }
        public string LastIp { get; set; }
        public System.DateTime DateCreated { get; set; }
        public Nullable<System.DateTime> DateModified { get; set; }
        public IList<UserLocation> UserLocations { get; set; }

        private IList<AppUserRole> _appUserRole;
        public virtual IList<AppUserRole> AppUserRoles
        {
            get { return _appUserRole; }
            set { _appUserRole = value; }
        }
        

        #region public methods

        private AccessLevel[] _permissions = new AccessLevel[0];

        [NotMapped]
        public AccessLevel[] Permissions
        {
            get
            {
                if (this._permissions.Length == 0)
                {
                    ArrayList permissions = new ArrayList();
                    foreach (AppUserRole role in AppUserRoles)
                    {
                        foreach (AccessLevel permission in role.Role.Permissions)
                        {
                            if (permissions.IndexOf(permission) == -1)
                                permissions.Add(permission);
                        }
                    }
                    this._permissions = (AccessLevel[])permissions.ToArray(typeof(AccessLevel));
                }
                return this._permissions;
            }
        }

        public bool HasPermission(AccessLevel permission)
        {
            return Array.IndexOf(this.Permissions, permission) > -1;
        }

        public bool CanView(Node node)
        {
            foreach (NodeRole p in node.NodeRoles)
            {
                if (p.ViewAllowed && IsInRole(p.Role))
                {
                    return true;
                }
            }
            return false;
        }

        public bool CanEdit(Node node)
        {
            foreach (NodeRole p in node.NodeRoles)
            {
                if (p.EditAllowed && IsInRole(p.Role))
                {
                    return true;
                }
            }
            return false;
        }

        public static string HashPassword(string password)
        {
            if (ValidatePassword(password))
            {
                return Encryption.StringToMD5Hash(password);
            }
            else
            {
                throw new ArgumentException("Invalid password");
            }
        }

        public static bool ValidatePassword(string password)
        {
            return (password.Length >= 5);
        }

        public bool IsInRole(Role roleToCheck)
        {
            foreach (AppUserRole role in this.AppUserRoles)
            {
                if (role.Role.Id == roleToCheck.Id && role.Role.Name == roleToCheck.Name)
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsInRole(string roleName)
        {
            foreach (AppUserRole role in this.AppUserRoles)
            {
                if (role.Role.Name == roleName)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region IIdentity Members

        public string AuthenticationType
        {
            get { return "RamcsAuthentication"; }
        }

        private bool _isAuthenticated = false;
        [NotMapped]
        public bool IsAuthenticated
        {
            get { return this._isAuthenticated; }
            set { this._isAuthenticated = value; }
        }

        [NotMapped]
        public string Name
        {
            get
            {
                if (this._isAuthenticated)
                    return Id.ToString();
                else
                    return "";
            }
        }
        [NotMapped]
        public string FullName
        {
            get { return this.FirstName + " " + this.LastName; }
        }

        #endregion
        #region UserLocation

        public UserLocation GetUserLocation(int Id)
        {
            foreach (UserLocation ul in UserLocations)
            {
                if (ul.Id == Id)
                    return ul;
            }
            return null;
        }

        public UserLocation GetUserLocationByLabCode(String labCode)
        {
            foreach (UserLocation ul in UserLocations)
            {                
                if (ul.LabCode == labCode)
                    return ul;
            }
            return null;
        }

        //Added by ZaySoe on 12-Nov-18
        public List<UserLocation> GetUserLocationbyNational()
        {
            List<UserLocation> list = new List<UserLocation>();
            foreach (UserLocation ul in UserLocations)
            {
                list.Add(ul);
            }
            return list;

            //if (UserLocations.Count > 0)
            //    return GetUserLocationbyProvince(UserLocations[0].province.Id);
            //return null;
        }

        public List<UserLocation> GetUserLocationbyProvince(int provinceId)
        {
            List<UserLocation> list = new List<UserLocation>();
            foreach (UserLocation ul in UserLocations)
            {
                if (ul.province != null)
                {
                    if (ul.province.Id == provinceId)
                        list.Add(ul);
                }

            }
            return list;
        }

        public List<UserLocation> GetUserLocationbyDistrict(int districtId)
        {
            List<UserLocation> list = new List<UserLocation>();
            foreach (UserLocation ul in UserLocations)
            {
                if (ul.District.Id == districtId)
                {
                    list.Add(ul);
                }
            }
            return list;
        }

        public List<UserLocation> GetUserLocationbyLLG(int LLGId)
        {
            List<UserLocation> list = new List<UserLocation>();
            foreach (UserLocation ul in UserLocations)
            {
                if (ul.LLG.Id == LLGId)
                {
                    list.Add(ul);
                }
            }
            return list;
        }

        public List<UserLocation> GetUserLocationbyFacility(int FacilityId)
        {
            List<UserLocation> list = new List<UserLocation>();
            foreach (UserLocation ul in UserLocations)
            {
                if (ul.Facility.Id == FacilityId)
                {
                    list.Add(ul);
                }
            }
            return list;
        }

        //public UserLocation GetUserLocationbyProvince(int provinceId)
        //{
        //    foreach (UserLocation ul in UserLocations)
        //    {
        //        if (ul.province != null)
        //        {
        //            if (ul.province.Id == provinceId)
        //            {
        //                return ul;
        //            }
        //            if (ul.province == null && ul.Id > 0)
        //            {
        //                return ul;
        //            }
        //        }

        //    }
        //    return null;
        //}
        //public UserLocation GetUserLocationbyDistrict(int districtId)
        //{
        //    foreach (UserLocation ul in UserLocations)
        //    {
        //        if (ul.District.Id == districtId)
        //        {
        //            return ul;
        //        }
        //    }
        //    return null;
        //}
        //public UserLocation GetUserLocationbyLLG(int LLGId)
        //{
        //    foreach (UserLocation ul in UserLocations)
        //    {
        //        if (ul.LLG.Id == LLGId)
        //        {
        //            return ul;
        //        }
        //    }
        //    return null;
        //}
        //public UserLocation GetUserLocationbyFacility(int FacilityId)
        //{
        //    foreach (UserLocation ul in UserLocations)
        //    {
        //        if (ul.Facility.Id == FacilityId)
        //        {
        //            return ul;
        //        }
        //    }
        //    return null;
        //}
        public UserLocation GetUserLocationbyLab(string labcode)
        {
            foreach (UserLocation ul in UserLocations)
            {
                if (ul.LabCode== labcode)
                {
                    return ul;
                }
            }
            return null;
        }
        //public void RemoveUserLocation(int Id)
        //{
        //    foreach (UserLocation ul in UserLocations)
        //    {
        //        if (ul.Id == Id)
        //        {
        //            UserLocations.Remove(ul);
        //            break;
        //        }
        //    }

        //}

        //Added by ZaySoe on 07-Nov-2018
        public void RemoveUserLocation(int Id, int depth, bool isLabCode)
        {
            if (isLabCode)
            {
                foreach (UserLocation ul in UserLocations)
                {
                    if (Convert.ToInt32(ul.LabCode) == Id)
                    {
                        UserLocations.Remove(ul);
                        break;
                    }
                }
            }
            else
            {
                ArrayList delUserLocList = new ArrayList();
                if (depth == 0)
                {
                    for (int i = 0; i < UserLocations.Count; i++)
                        UserLocations.RemoveAt(i);
                }
                else if (depth == 1)
                {
                    for (int i = 0; i < UserLocations.Count; i++)
                    {
                        if (UserLocations[i].province.Id == Id)
                            delUserLocList.Add(UserLocations[i]);
                    }
                }
                else if (depth == 2)
                {
                    for (int i = 0; i < UserLocations.Count; i++)
                    {
                        if (UserLocations[i].District.Id == Id)
                            delUserLocList.Add(UserLocations[i]);
                    }
                }
                else if (depth == 3)
                {
                    for (int i = 0; i < UserLocations.Count; i++)
                    {
                        if (UserLocations[i].LLG.Id == Id)
                            delUserLocList.Add(UserLocations[i]);
                    }
                }
                else if (depth == 4)
                {
                    for (int i = 0; i < UserLocations.Count; i++)
                    {
                        if (UserLocations[i].Id == Id)
                            delUserLocList.Add(UserLocations[i]);
                    }
                }

                foreach (UserLocation ul in delUserLocList)
                {
                    UserLocations.Remove(ul);
                }
            }
        }
        #endregion
    }

}
