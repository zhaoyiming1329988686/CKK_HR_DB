//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class training
    {
        public short tra_id { get; set; }
        public string major_kind_id { get; set; }
        public string major_kind_name { get; set; }
        public string major_id { get; set; }
        public string major_name { get; set; }
        public string human_id { get; set; }
        public string human_name { get; set; }
        public string training_item { get; set; }
        public Nullable<System.DateTime> training_time { get; set; }
        public Nullable<int> training_hour { get; set; }
        public string training_degree { get; set; }
        public string register { get; set; }
        public string checker { get; set; }
        public Nullable<System.DateTime> regist_time { get; set; }
        public Nullable<System.DateTime> check_time { get; set; }
        public Nullable<short> checkstatus { get; set; }
        public string remark { get; set; }
    }
}
