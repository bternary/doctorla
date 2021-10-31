using System;

namespace Models
{
    public class Menu
    {
        public int Id { get; set; }
        public int TypeID { get; set; }
        public int ParentId { get; set; }
        public string Name { get; set; }
        public string DefaultName { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public List<Menu> ChildMenu { get; set; }
    }
}
