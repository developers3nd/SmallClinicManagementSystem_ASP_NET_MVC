//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace smallclinicMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public partial class Expense
    {
        public int ExpenseID { get; set; }

        [DataType(DataType.Date)]
        public Nullable<System.DateTime> ExpenseDate { get; set; }
        public string ExpenseDescription { get; set; }
        public Nullable<decimal> Amount { get; set; }
    }
}
