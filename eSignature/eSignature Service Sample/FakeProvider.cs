using System;
using System.Collections.Generic;

namespace SDKSamples.ESignature
{
    //this class takes over the work of the eSignature provider for this sample in a very simplified matter
    public class FakeProvider
    {
        private static List<Document> _documents = new List<Document>(); //this is the fake storage backend of the fake provider

        #region document handling
        public string NewDocument(string data, string filename, string context)
        {
            lock(_documents)
            {
                //add new document. use new guid for document id
                Document newdoc = new Document { DocumentID = new Guid().ToString(), Data = data, Filename = filename, Context = context };
                _documents.Add(newdoc);
                return newdoc.DocumentID; //return id to Therefore
            }
        }

        public Document GetDocument(string documentid)
        {
            return _documents.Find(x => x.DocumentID == documentid);
        }

        public void RemoveDocument(string documentid)
        {
            lock(_documents)
            {
                Document doc = GetDocument(documentid);
                _documents.Remove(doc);
            }
        }

        public List<Document> GetRejected()
        {
            lock (_documents)
            {
                List<Document> rejected = new List<Document>();
                foreach (Document doc in _documents)
                {
                    if(doc.State == DocumentState.New)
                    {
                        //randomly choose which document is rejected if state is new
                        Random r = new Random();
                        if (r.Next(0, 2) == 1)
                            doc.State = DocumentState.Rejected;
                    }
                }
                return rejected;
            }
        }

        public List<Document> GetSigned()
        {
            lock (_documents)
            {
                List<Document> signed = new List<Document>();
                foreach (Document doc in _documents)
                {
                    if (doc.State == DocumentState.New)
                    {
                        //randomly choose which document is signed if state is new
                        Random r = new Random();
                        if (r.Next(0, 2) == 1)
                            doc.State = DocumentState.Signed;
                    }
                }
                return signed;
            }
        }
        #endregion

        #region template handling
        public List<Template> GetTemplates()
        {
            //return a static list. this ensures that the templates saved with a configuration in the "Send for Signing" workflow task will always work.
            List<Template> templates = new List<Template>();
            templates.Add(new Template
            {
                TemplateID = "653245C1-2FC8-4802-9A09-3D54AA3F1320",
                Name = "Test Template 1",
                Fields = new List<TemplateProperty>
                {
                    new TemplateProperty { ID = "field1_id", Name = "Template Field 1" },
                    new TemplateProperty { ID = "field2_id", Name = "Template Field 2" },
                }
            });
            
            templates.Add(new Template 
            { 
                TemplateID = "01B384C5-9470-49E6-BFFA-5D498AB0BB4B", 
                Name = "Test Template 2",
                Fields = new List<TemplateProperty>
                {
                    new TemplateProperty { ID = "field3_id", Name = "Template Field 3" },
                    new TemplateProperty { ID = "field4_id", Name = "Template Field 4" },
                }
            });
            return templates;
        }

        public List<TemplateProperty> GetTemplateFields(string templateid)
        {
            Template template = GetTemplates().Find(x => x.TemplateID == templateid);
            if (template == null)
                throw new Exception($"Template {templateid} does not exist.");
            return template.Fields;
        }
        #endregion
    }    
}
