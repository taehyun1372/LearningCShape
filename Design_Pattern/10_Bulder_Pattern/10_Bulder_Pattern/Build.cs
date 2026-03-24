using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using System.Xml.Linq;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace _10_Bulder_Pattern
{

    public class Director
    {
        private Builder _builder;
        public Director(Builder builder)
        {
            _builder = builder;
        }

        public void Build(string content)
        {
            _builder.FileCreate();
            _builder.ContentFormatting(content);
            _builder.FileSave();
            _builder.Dispose();
        }
    }

    public abstract class Builder
    {
        private string _path;
        public string Path
        {
            get { return _path; }
            set { _path = value; }
        }
        public Builder(string path)
        {
            Path = path;
        }
        public abstract void FileCreate();
        public abstract void ContentFormatting(string content);
        public abstract void FileSave();
        public abstract void Dispose();

    }

    public class TextBuilder : Builder
    {
        public TextBuilder(string path) : base(path)
        {

        }

        public override void FileCreate()
        {
            return;
        }

        public override void ContentFormatting(string content)
        {
            File.WriteAllText(Path, content);
        }

        public override void FileSave()
        {
            return;
        }

        public override void Dispose()
        {
            return;
        }
    }

    public class JsonBuilder : Builder
    {
        public JsonBuilder(string path) : base(path)
        {
        }

        public override void ContentFormatting(string content)
        {
            var obj = new
            {
                title = "Sample Report",
                content = content
            };

            string json = JsonSerializer.Serialize(obj, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            File.WriteAllText(Path, json);

        }

        public override void Dispose()
        {
            return;
        }

        public override void FileCreate()
        {
            return;
        }

        public override void FileSave()
        {
            return;
        }
    }


    public class XMLBuilder : Builder
    {
        public XMLBuilder(string path):base(path)
        {

        }
        public override void ContentFormatting(string content)
        {
            var doc = new XDocument();
            doc.Add(new XElement("report" ,
                new XElement("title", "Sample Report"),
                new XElement("content", content)));

            doc.Save(Path);
        }

        public override void Dispose()
        {
            return;
        }

        public override void FileCreate()
        {
            return;
        }

        public override void FileSave()
        {
            return;
        }
    }

    class PDFBuilder : Builder
    {
        public PDFBuilder(string path):base(path)
        {
            QuestPDF.Settings.License = LicenseType.Community;
        }
        public override void ContentFormatting(string content)
        {
            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Content().Column(col =>
                    {
                        col.Item().Text("Sample Report").FontSize(20);
                        col.Item().Text(content);
                    });
                });
            })
            .GeneratePdf("report.pdf");
        }

        public override void Dispose()
        {
            return;
        }

        public override void FileCreate()
        {
            return;
        }

        public override void FileSave()
        {
            return;
        }
    }
}
