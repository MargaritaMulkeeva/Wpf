//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ex2
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tasks
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tasks()
        {
            this.Control_Tasks = new HashSet<Control_Tasks>();
        }
    
        public int ID_Task { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public Nullable<System.DateTime> DeadLine { get; set; }
        public Nullable<System.DateTime> Data_Creation { get; set; }
        public Nullable<decimal> Norma_Time_In_Minutes { get; set; }
        public Nullable<decimal> Factor_Difficulty { get; set; }
        public Nullable<decimal> Factor_Priority { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Control_Tasks> Control_Tasks { get; set; }
    }
}
