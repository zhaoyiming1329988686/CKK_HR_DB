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
    
    public partial class engage_exam
    {
        public short exa_id { get; set; }
        public string exam_number { get; set; }
        public string major_kind_id { get; set; }
        public string major_kind_name { get; set; }
        public string major_id { get; set; }
        public string major_name { get; set; }
        public string register { get; set; }
        public Nullable<System.DateTime> regist_time { get; set; }
        public Nullable<short> limite_time { get; set; }
    }
}
