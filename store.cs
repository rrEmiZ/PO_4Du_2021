//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace lab11NieWiemCzyDobrzeKlikam
{
    using System;
    using System.Collections.Generic;
    
    public partial class store
    {
        public store()
        {
            this.stocks = new HashSet<stock>();
            this.orders = new HashSet<order>();
            this.staffs = new HashSet<staff>();
        }
    
        public int store_id { get; set; }
        public string store_name { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string street { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zip_code { get; set; }
    
        public virtual ICollection<stock> stocks { get; set; }
        public virtual ICollection<order> orders { get; set; }
        public virtual ICollection<staff> staffs { get; set; }
    }
}
