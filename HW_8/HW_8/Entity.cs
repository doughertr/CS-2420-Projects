using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_8
{
    class Entity
    {
        public Entity()
        {
            Position = new Point();
            components = new List<Component>();
        }
        public List<Component> components { get; set; }

        public void AddComponent(Component addedComponent)
        {
            components.Insert(0, addedComponent);
            addedComponent.EntityParent = this;
        }
        public bool RemoveComponent(Component Component)
        {
            return components.Remove(Component);
        }
        public void ClearComponents()
        {
            components = new List<Component>();
        }
        public void Update()
        {

            for(int i = 0; i < components.Count; i++)
            {
                components[i].Update();
            }
        }
        public Point Position { get; set; }
    }

}
