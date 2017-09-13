using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProductionSchedulerLibrary
{

    public class SFC_Bom 
    {
        private readonly long id;

        private SFC_Item itemId;

        private SFC_BomComposite thisBom;

        public long Id => id;

        public SFC_Item ItemId { get => itemId; protected set => itemId = value; }


        public SFC_Bom(long id, SFC_Item itemId)
        {
            this.id = id;
            this.itemId = itemId;
            this.thisBom = new SFC_BomComposite(id, itemId, 1);
        }


        public void Add(SFC_BomComponent c)
        {
            this.thisBom.Add(c);
        }

        public void Remove(SFC_BomComponent c)
        {
            this.thisBom.Remove(c);
        }

        public override string ToString()
        {        
            StringBuilder sb = new StringBuilder();
            sb.Append("BOM:" + this.itemId);
            sb.Append(this.thisBom.Display(1));
            return sb.ToString();
        }

       

    }






}
