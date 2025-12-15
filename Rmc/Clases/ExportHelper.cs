using System.IO;
using System.Windows.Forms;
using System;
using Telerik.WinControls;

public static class ExportHelper
{
    public static bool ExportToExcel(Telerik.WinControls.UI.RadGridView gridView, string defaultFileName = "Reporte")
    {
        if (gridView.RowCount == 0)
        {
            RadMessageBox.Show("No hay datos para exportar.", "Atención", MessageBoxButtons.OK, RadMessageIcon.Info);
            return false;
        }

        using (SaveFileDialog sfd = new SaveFileDialog())
        {
            sfd.Filter = "Excel Files (*.xlsx)|*.xlsx";
            sfd.FileName = $"{defaultFileName}_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (File.Exists(sfd.FileName) && IsFileInUse(sfd.FileName))
                    {
                        RadMessageBox.Show("El archivo está abierto en otra aplicación. Ciérrelo e intente de nuevo.",
                            "Error", MessageBoxButtons.OK, RadMessageIcon.Error);
                        return false;
                    }

                    Telerik.WinControls.Export.GridViewSpreadExport exporter =
                        new Telerik.WinControls.Export.GridViewSpreadExport(gridView);
                    exporter.ExportVisualSettings = false;
                    exporter.ExportHierarchy = false;
                    exporter.SheetName = Path.GetFileNameWithoutExtension(defaultFileName);

                    Telerik.WinControls.Export.SpreadExportRenderer renderer =
                        new Telerik.WinControls.Export.SpreadExportRenderer();

                    exporter.RunExport(sfd.FileName, renderer);

                    RadMessageBox.Show($"Exportación completada exitosamente.\nArchivo: {Path.GetFileName(sfd.FileName)}",
                        "Éxito", MessageBoxButtons.OK, RadMessageIcon.Info);
                    return true;
                }
                catch (IOException ioEx)
                {
                    RadMessageBox.Show($"No se puede acceder al archivo: {ioEx.Message}\n\nAsegúrese de que Excel no tenga el archivo abierto.",
                        "Error", MessageBoxButtons.OK, RadMessageIcon.Error);
                    return false;
                }
                catch (Exception ex)
                {
                    RadMessageBox.Show("Error al exportar: " + ex.Message, "Error", MessageBoxButtons.OK, RadMessageIcon.Error);
                    return false;
                }
            }
        }
        return false;
    }

    private static bool IsFileInUse(string filePath)
    {
        try
        {
            if (!File.Exists(filePath))
                return false;

            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.ReadWrite, FileShare.None))
            {
                return false;
            }
        }
        catch (IOException)
        {
            return true;
        }
        catch (UnauthorizedAccessException)
        {
            return true;
        }
    }
}