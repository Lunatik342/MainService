//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MainService
{
    using System;
    using System.Collections.Generic;
    
    public partial class Event
    {
        public long event_id { get; set; }
        public long channel_id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public System.DateTime event_time { get; set; }
        public System.DateTime creation_time { get; set; }
        public Nullable<long> improtance_id { get; set; }
    
        public virtual Channel Channel { get; set; }
        public virtual Importance Importance { get; set; }
    }
}
