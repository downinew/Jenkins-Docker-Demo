using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.ServiceModel.Activities;
using System.Text;
using System.Threading.Tasks;

namespace WarehouseService
{
    class WorkFlowLoader
    {

        public WorkflowService LoadWorkFlow()
        {
            Assembly a = Assembly.Load(@"WcfServiceLibrary1.dll");
            Type myType = a.GetType("Service2");
            return (WorkflowService)Activator.CreateInstance(myType);
        }


    }
}
