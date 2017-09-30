using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionSchedulerLibrary
{
    public class ShopSequenceGenerator
    {
        private static ShopSequenceGenerator instance = null;

        private static Object lockObject = new Object();

        private readonly static Dictionary<String, ModelSequencer> modelSequence = new Dictionary<string, ModelSequencer>();

        private ShopSequenceGenerator()
        {

        }

        public static ShopSequenceGenerator Instance
        {
            get
            {
                lock (lockObject)
                {
                    if (instance == null)
                    {
                        instance = new ShopSequenceGenerator();
                    }
                }
                return instance;
            }
        }

        public void CreateNewSequence(String prefix, long lastNumber)
        {
            ModelSequencer seq = new ModelSequencer(prefix, lastNumber);
            modelSequence.Add(prefix, seq);
        }

        public void FormatSpecifier(String prefix, String format, bool isPrefixed)
        {
            if (modelSequence.ContainsKey(prefix))
            {
                modelSequence[prefix].SetFormat(format, isPrefixed);
            }
        }


        public void SetLastValue(String prefix, long lastValue)
        {
            if (modelSequence.ContainsKey(prefix))
            {
                modelSequence[prefix].SetLastValue(lastValue);
            }
        }

        public long GetNext(String prefix)
        {
            if (modelSequence.ContainsKey(prefix))
            {
                return modelSequence[prefix].GetNext();
            }
            else
            {
                ModelSequencer seq = new ModelSequencer(prefix, 1);
                modelSequence.Add(prefix, seq);
                return 1;
            }
        }

        public String GetPattern(String prefix)
        {
            if (modelSequence.ContainsKey(prefix))
            {
                return modelSequence[prefix].GetFormattedNext();
            }
            else
            {
                ModelSequencer seq = new ModelSequencer(prefix, 1);
                modelSequence.Add(prefix, seq);
                return modelSequence[prefix].GetFormattedNext();
            }
        }

        public String GetYYYYMMPattern(String prefix)
        {
            if (modelSequence.ContainsKey(prefix))
            {
                return modelSequence[prefix].GetYYMMFormatted();
            }
            else
            {
                ModelSequencer seq = new ModelSequencer(prefix, 1);
                modelSequence.Add(prefix, seq);
                return modelSequence[prefix].GetYYMMFormatted();
            }
        }

        public String GetNextPattern(String prefix)
        {
            if (modelSequence.ContainsKey(prefix))
            {
                return modelSequence[prefix].GetFormattedNext();
            }
            else
            {
                ModelSequencer seq = new ModelSequencer(prefix, 1);
                modelSequence.Add(prefix, seq);
                return modelSequence[prefix].GetFormattedNext();
            }
        }

        protected class ModelSequencer
        {
            private static long lastSequence = 0;
            private static Object lockObject = new Object();
            private String prefix;
            private String formatSpecifier = "{0:D10}";
            private bool isPrefixed;

            public ModelSequencer(String seqName, long n)
            {
                this.prefix = seqName;
                this.isPrefixed = false;
                lastSequence = n;
            }

            public void SetLastValue(long n)
            {
                lock (lockObject)
                {
                    lastSequence = n;
                }
            }

            public void SetFormat(String format, bool isPrefixed)
            {
                this.formatSpecifier = format;
                this.isPrefixed = isPrefixed;
            }

            public long GetNext()
            {
                lock (lockObject)
                {
                    unchecked { lastSequence++; }
                    return lastSequence;
                }
            }

            public String GetFormatted()
            {
                if (isPrefixed)
                    return String.Format(prefix + formatSpecifier, lastSequence);
                else
                    return String.Format(formatSpecifier, lastSequence);
            }

            public String GetFormattedNext()
            {
                lock (lockObject)
                {
                    unchecked { lastSequence++; }
                    if (isPrefixed)
                        return String.Format(prefix + formatSpecifier, lastSequence);
                    else
                        return String.Format(formatSpecifier, lastSequence);
                }
            }

            public String GetYYMMFormatted()
            {
                if (isPrefixed)
                    return String.Format(prefix + "{1:yy}-{1:MM}-" + formatSpecifier, lastSequence, DateTime.Now);
                else
                    return String.Format("{1:yy}-{1:MM}-" + formatSpecifier, lastSequence, DateTime.Now);
            }


        }

    }
}
