﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Complex.Common.Utility;


namespace Complex.Entity.Admin
{
    [Description("操作按钮")]
    [Table("T_Button")]
    public class T_Button : EntityBase
    { 
        [Description("按钮名称")]
        public string ButtonText { get; set; }
        [Description("排序")]
        public int Sortnum { get; set; }
        [Description("图标class")]
        public string iconCls { get; set; }
        [Description("图标路径")]
        public string IconUrl { get; set; }
        [Description("按钮标识")]
        public string ButtonTag { get; set; }
        [Description("描述")]
        public string Remark { get; set; }

        [Description("是否为系统菜单")]
        public bool IsSys { get; set; }
         
        [Description("按钮HTML")]
        public string ButtonHtml
        {
            get
            {
                return string.Format(
                            "<a id=\"a_{0}\" style=\"float:left\" href=\"javascript:;\" plain=\"true\" class=\"easyui-linkbutton\" icon=\"{1}\" title=\"{2}\">{2}</a>",
                            this.ButtonTag, this.iconCls, this.ButtonText);
            }
        }

        //public override string ToString()
        //{
        //    return JSONhelper.ToJson(this);
        //}

    }
    
}
