//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HerculesSystem.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class users
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public int ParentAccount { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        public Nullable<System.DateTime> LastLogin { get; set; }
        public Nullable<bool> LoggedIn { get; set; }
        public string Photo { get; set; }
        public Nullable<int> Role { get; set; }
        public Nullable<bool> RecieveNotifications { get; set; }
        public Nullable<int> AlarmForwardingMethod { get; set; }
        public int CompanyID { get; set; }
    
        public virtual company company { get; set; }
    }
}
