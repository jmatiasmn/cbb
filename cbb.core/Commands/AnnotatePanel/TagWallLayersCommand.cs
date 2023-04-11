using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Electrical;
using Autodesk.Revit.UI;
using cbb.core.Commands.Helpers;
using cbb.core.Commands.Helpers.Type;
using cbb.core.Commands.Selection;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cbb.core
{
    [Transaction(TransactionMode.Manual)]
    [Regeneration(RegenerationOption.Manual)]
    public class TagWallLayersCommand : IExternalCommand
    {
        public Result Execute(ExternalCommandData commandData, ref string message, ElementSet elements)
        {
            UIDocument uidoc = commandData.Application.ActiveUIDocument;
            Document doc = uidoc.Document;

            //Check if we are in Revit project, not in family one
            if (doc.IsFamilyDocument)
            {
                Message.Display("Cant user command in family document", Commands.Helpers.Type.WindowType.Warning);
                    return Result.Cancelled;
            }

            //Get acess do current View
            View activeView = uidoc.ActiveView;

            //Check if text note can be created in currently active view
            bool canCreateTextNoteInView = false;

            switch (activeView.ViewType)
            {
                case ViewType.FloorPlan:
                    canCreateTextNoteInView = true;
                    break;
                case ViewType.CeilingPlan:
                    canCreateTextNoteInView = true;
                    break;

                case ViewType.Detail:
                    canCreateTextNoteInView = true;
                    break;
                case ViewType.Elevation:
                    canCreateTextNoteInView = true;
                    break;
            }

            if (!canCreateTextNoteInView)
            {
                Message.Display("Text Note element can't be created in the current view", Commands.Helpers.Type.WindowType.Error);
                return Result.Cancelled;
            }

            //Ask user to select one basic wall
            Reference selectionReference = uidoc.Selection.PickObject(Autodesk.Revit.UI.Selection.ObjectType.Element, new SelectionFIlter("Walls"), "Select one basic wall");
            Wall selectionElement = doc.GetElement(selectionReference) as Wall;

            //Check if wall is type of basic wall
            if (selectionElement.IsStackedWall)
            {
                Message.Display("Wall you selected is category of the stacked wall.\nIt's not  supported by this command",WindowType.Error);
                return Result.Cancelled;
            }

            //Ask user to pick location point for the TextNote
            XYZ point = uidoc.Selection.PickPoint("Pick point");


            //Acess list of wall Layers
            IList<CompoundStructureLayer> layers = selectionElement.WallType.GetCompoundStructure().GetLayers();

            //Get Layer information in structured string format for Text Note.
            StringBuilder msg = new StringBuilder();
            foreach (CompoundStructureLayer layer in layers)
            {
                Material material = doc.GetElement(layer.MaterialId) as Material;
                msg.AppendLine(layer.Function.ToString() + " " + material.Name + " " + layer.Width.ToString());
            }

            //Create Textx Note Options.
            var textNoteOptions = new TextNoteOptions
            {
                VerticalAlignment = VerticalTextAlignment.Top,
                HorizontalAlignment = HorizontalTextAlignment.Left,
                TypeId = doc.GetDefaultElementTypeId(ElementTypeGroup.TextNoteType)
            };

            //Open Revit document transaction to create new  Note Element
            using (Transaction t = new Transaction(doc))
            {
                t.Start("Tag Wall Layers Command");

                //Create Texxt Note with wall layers information on user specified point in the current active view
                var textNote = TextNote.Create(doc, activeView.Id, point, msg.ToString(), textNoteOptions);

                t.Commit();

            }
            {

            }

            return Result.Succeeded;
        }


        /// <summary>
        /// Get the full namespace path to this command
        /// </summary>
        /// <returns></returns>
        public static string GetPath()
        {
            return typeof(TagWallLayersCommand).Namespace + "." + nameof(TagWallLayersCommand);
        }
    }
}