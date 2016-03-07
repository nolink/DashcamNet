using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DashcamNet
{
    public class TagBuilder
    {
        private Dictionary<String, String> tags;

        private TagBuilder(){
        this.tags = new Dictionary<string,string>();
    }

        public static TagBuilder create()
        {
            return new TagBuilder();
        }

        /**
         * Append the key-value pair tag
         * @param key
         * @param value
         * @return
         */
        public TagBuilder append(String key, Object value)
        {
            if (!String.IsNullOrEmpty(key))
            {
                this.tags.Add(key, value == null ? "NA" : value.ToString());
            }
            return this;
        }

        /**
         * Append other tags
         * @param attrs
         * @return
         */
        public TagBuilder append(Dictionary<String, String> attrs){
        if(attrs != null){
            foreach (String key in attrs.Keys){
                this.tags.Add(key, attrs[key]);
            }
        }

        return this;
    }

        /**
         * Tag1=xx,Tag2=yy,Tag3=zz
         * @param tagStr
         * @return
         */
        public TagBuilder append(String tagStr){
        if(!String.IsNullOrEmpty(tagStr)){
            String[] tgs = tagStr.Split(',');
            foreach (String tg in tgs){
                String[] kvs = tg.Split('=');
                if(kvs.Length == 2){
                    this.tags.Add(kvs[0], kvs[1]);
                }
            }
        }
        return this;
    }

        public Dictionary<String, String> build()
        {
            return tags;
        }
    }
}
