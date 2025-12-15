using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rmc.EntityFramework.Main
{
    class fn_mst_GetFormPermissions
    {
        public int App_ID { get; set; }
        public string Obj_Name { get; set; }
        public string Usr_Login { get; set; }
        public Nullable<int> PermisosLeer { get; set; }
        public Nullable<int> PermisosCrear { get; set; }
        public Nullable<int> PermisosEliminar { get; set; }
        public Nullable<int> PermisosActualizar { get; set; }
    }
}
