using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class ContentAssignmentCriteria
    {
        public string Ownership;

        public List<int> Ogs = new List<int>();

        public List<int> Ugs = new List<int>();

        public override bool Equals(object contentAssignmentCriteria)
        {
            var criteria = contentAssignmentCriteria as ContentAssignmentCriteria;

            if (criteria == null)
            {
                return false;
            }

            if (criteria.Ogs == null || criteria.Ugs == null)
            {
                return false;
            }

            if (this.Ownership != criteria.Ownership)
            {
                return false;
            }

            if (this.Ogs.SequenceEqual(criteria.Ogs) && this.Ugs.SequenceEqual(criteria.Ugs))
            {
                return true;
            }

            return false;
        }

        public override int GetHashCode()
        {
            int hash = 1;

            if (!string.IsNullOrWhiteSpace(this.Ownership))
            {
                hash ^= this.Ownership.GetHashCode();
            }

            if (this.Ogs != null)
            {
                hash ^= string.Join(',', this.Ogs).GetHashCode();
            }

            if (this.Ugs != null)
            {
                hash ^= string.Join(',', this.Ugs).GetHashCode();
            }

            return hash;
        }
    }

    public class ContentModel
    {
        public int ContentId;

        public int SmartGroupId;

        public ContentAssignmentCriteria Assignment;
    }

    internal class SgAssignment
    {
        public static void Solve()
        {
            //List<(int contentId, int ogId, int ugId)> list = new List<(int contentId, int ogId, int ugId)>
            //{
            //    (1, 20, 0),
            //    (1, 21, 30),
            //    (1, 22, 0),
            //    (2, 20, 0),
            //    (2, 21, 30),
            //    (2, 22, 0),
            //    (3, 21, 31),
            //    (3, 0, 32),
            //    (3, 0, 33),
            //};

            List<(int contentId, string ownership)> contentIds = new List<(int contentId, string ownership)> 
            { 
                (1, "Any"), (2, "Any"), (3, "Any") 
            };
            List<(int contentId, int OgId)> OgIds = new List<(int contentId, int OgId)>
            {
                    (1, 20),
                    (1, 21),
                    (1, 22),
                    (2, 20),
                    (2, 21),
                    (2, 22),
                    (3, 21),
            };

            List<(int contentId, int UgId)> UgIds = new List<(int contentId, int UgId)>
            {
                (1, 30),
                (2, 30),
                (3, 31),
                (3, 32),
                (3, 33),
            };

            List<ContentModel> contentModels = new List<ContentModel>();
            Hashtable ht = new Hashtable(); ht.Add(1, "21");
            HashSet<int> hs = new HashSet<int>(); hs.Add(1);
            //Dictionary<int, List<>>

            List<ContentModel> contents = new List<ContentModel>();

            foreach (var content in contentIds)
            {
                var ogs = OgIds.Where(x => x.contentId == content.contentId).Select(x => x.OgId);
                var ugs = UgIds.Where(x => x.contentId == content.contentId).Select(x => x.UgId);

                contents.Add
                (
                    new ContentModel
                    {
                        ContentId = content.contentId,
                        Assignment = new ContentAssignmentCriteria
                        {
                            Ownership = content.ownership,
                            Ogs = ogs.ToList(),
                            Ugs = ugs.ToList(),
                        },
                    }
                );
            }

            var itemToCompare = contents[0];

            foreach(var content in contents)
            {
                if (content.Assignment.Equals(itemToCompare.Assignment) && content.Assignment.GetHashCode() == itemToCompare.Assignment.GetHashCode())
                {

                }
            }
        }
    }
}
