using System;

public class ItemInv
{
    public int ItemID { get; set; }
    public string Code { get; set; }
    public string Description { get; set; }
    public string Carnet {  get; set; }
    public string MaterialType { get; set; }
    public decimal TotalQuantity { get; set; }
    public string Location { get; set; }
    public string BoxID { get; set; }
    public DateTime CreatedDate { get; set; }
    public string CreatedBy { get; set; }
    public string Name { get; set; }
    public DateTime? ModifiedDate { get; set; }
    public string ModifiedBy { get; set; }
    public int WarehouseID { get; set; }
    public string WarehouseName { get; set; }
}
