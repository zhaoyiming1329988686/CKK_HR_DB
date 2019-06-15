using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity.Configuration;
using System.Configuration;
using Unity;

namespace IOC
{
    public class IocCreate
    {
        public static T CreateDao<T>(string jiedian1, string jiedian2)
        {
            UnityContainer ioc = CreatIoc(jiedian1);
            T jd = ioc.Resolve<T>(jiedian2);
            return jd;
        }
        private static UnityContainer CreatIoc(string name)
        {
            UnityContainer ioc = new UnityContainer();
            //把Untity文件转换成对象
            ExeConfigurationFileMap exf = new ExeConfigurationFileMap();
            exf.ExeConfigFilename = @"E:\Y2\riview\结业项目\CKK_HR_DB\结业项目\UI\Unity.config";
            //把Untity文件文件对象转成了配置对象
            Configuration cf = ConfigurationManager.OpenMappedExeConfiguration(exf, ConfigurationUserLevel.None);
            //读取配置对象中的Unity节点
            UnityConfigurationSection cfs = (UnityConfigurationSection)cf.GetSection("unity");
            //把containerOne节点装入容器
            ioc.LoadConfiguration(cfs, name);
            return ioc;
        }


        public static T CreateBLL<T>(string jiedian1, string jiedian2)
        {
            UnityContainer ioc = CreatIoc(jiedian1);
            T jd = ioc.Resolve<T>(jiedian2);
            return jd;
        }


    }
}
