//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ModelLibrary
{
    using System;
    using System.Collections.Generic;
    
    public partial class Employee
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Employee()
        {
            this.Boms = new HashSet<Bom>();
            this.BomDetails = new HashSet<BomDetail>();
            this.BomItemTypes = new HashSet<BomItemType>();
            this.BomMfgConsumables = new HashSet<BomMfgConsumable>();
            this.BomOtherCostDetails = new HashSet<BomOtherCostDetail>();
            this.EngineeringChangeStatus = new HashSet<EngineeringChangeStatu>();
            this.EngineeringPhases = new HashSet<EngineeringPhase>();
            this.FamilyRouters = new HashSet<FamilyRouter>();
            this.FamilyRouterLinks = new HashSet<FamilyRouterLink>();
            this.ManufacturedComponents = new HashSet<ManufacturedComponent>();
            this.ManufacturedSubComponents = new HashSet<ManufacturedSubComponent>();
            this.ProductBuilds = new HashSet<ProductBuild>();
            this.ProductBuildBomLinks = new HashSet<ProductBuildBomLink>();
            this.ProductBuildDetails = new HashSet<ProductBuildDetail>();
            this.ProductBuildDevelopmentLabors = new HashSet<ProductBuildDevelopmentLabor>();
            this.ProductBuildDrafts = new HashSet<ProductBuildDraft>();
            this.ProductBuildInvestments = new HashSet<ProductBuildInvestment>();
            this.ProductBuildMaterials = new HashSet<ProductBuildMaterial>();
            this.ProductBuildRouterLinks = new HashSet<ProductBuildRouterLink>();
            this.Routers = new HashSet<Router>();
            this.RouterActions = new HashSet<RouterAction>();
            this.RouterDetails = new HashSet<RouterDetail>();
            this.RouterOutsideDetails = new HashSet<RouterOutsideDetail>();
            this.RouterProcesses = new HashSet<RouterProcess>();
            this.RouterProcessDetails = new HashSet<RouterProcessDetail>();
            this.RouterTypes = new HashSet<RouterType>();
            this.Companies = new HashSet<Company>();
            this.Customers = new HashSet<Customer>();
            this.Items = new HashSet<Item>();
            this.ItemStatus = new HashSet<ItemStatu>();
            this.Locations = new HashSet<Location>();
            this.LocationDetails = new HashSet<LocationDetail>();
            this.Vendors = new HashSet<Vendor>();
            this.Employee1 = new HashSet<Employee>();
            this.ItemLocations = new HashSet<ItemLocation>();
            this.ItemLotBins = new HashSet<ItemLotBin>();
            this.ItemSerials = new HashSet<ItemSerial>();
            this.Machines = new HashSet<Machine>();
            this.MachineTypes = new HashSet<MachineType>();
            this.MfgConsumables = new HashSet<MfgConsumable>();
            this.MfgConsumableTypes = new HashSet<MfgConsumableType>();
            this.ScheduledWorkOrders = new HashSet<ScheduledWorkOrder>();
            this.StockMovements = new HashSet<StockMovement>();
            this.StockMovements1 = new HashSet<StockMovement>();
            this.StockMovementDetails = new HashSet<StockMovementDetail>();
            this.TeamGroups = new HashSet<TeamGroup>();
            this.TeamGroupEmployeeDetails = new HashSet<TeamGroupEmployeeDetail>();
            this.TeamGroupEmployeeDetails1 = new HashSet<TeamGroupEmployeeDetail>();
            this.TeamGroupMachineDetails = new HashSet<TeamGroupMachineDetail>();
            this.ToolSets = new HashSet<ToolSet>();
            this.ToolSetDetails = new HashSet<ToolSetDetail>();
            this.WorkCenters = new HashSet<WorkCenter>();
            this.WorkCenterGroups = new HashSet<WorkCenterGroup>();
            this.WorkCenterTypes = new HashSet<WorkCenterType>();
            this.WorkOrders = new HashSet<WorkOrder>();
            this.WorkOrderDetails = new HashSet<WorkOrderDetail>();
        }
    
        public long Id { get; set; }
        public long CompanyId { get; set; }
        public int EmployeeTypeId { get; set; }
        public string EmployeeNo { get; set; }
        public Nullable<System.DateTime> HiredDate { get; set; }
        public Nullable<System.DateTime> StartedDate { get; set; }
        public Nullable<System.DateTime> ProbationEndDate { get; set; }
        public Nullable<System.DateTime> TerminatedDate { get; set; }
        public Nullable<System.DateTime> LastEvaluation { get; set; }
        public Nullable<System.DateTime> NextEvaluation { get; set; }
        public Nullable<long> EmergencyContactPersonId { get; set; }
        public Nullable<long> EducationId { get; set; }
        public string TaxIdentificationNo { get; set; }
        public string SssNo { get; set; }
        public Nullable<long> PositionId { get; set; }
        public Nullable<long> ModifiedByEmployeeId { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<long> PrimaryDepartmentId { get; set; }
        public long PersonId { get; set; }
        public bool IsDeleted { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<System.DateTime> ModifiedOn { get; set; }
        public Nullable<System.DateTime> LastRaise { get; set; }
        public Nullable<long> SpecificationId { get; set; }
        public bool IsTerminated { get; set; }
        public bool IsInactive { get; set; }
        public Nullable<int> SecurityClearanceId { get; set; }
        public Nullable<long> AssignedLocatoinId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Bom> Boms { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BomDetail> BomDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BomItemType> BomItemTypes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BomMfgConsumable> BomMfgConsumables { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BomOtherCostDetail> BomOtherCostDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EngineeringChangeStatu> EngineeringChangeStatus { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EngineeringPhase> EngineeringPhases { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FamilyRouter> FamilyRouters { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FamilyRouterLink> FamilyRouterLinks { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ManufacturedComponent> ManufacturedComponents { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ManufacturedSubComponent> ManufacturedSubComponents { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductBuild> ProductBuilds { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductBuildBomLink> ProductBuildBomLinks { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductBuildDetail> ProductBuildDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductBuildDevelopmentLabor> ProductBuildDevelopmentLabors { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductBuildDraft> ProductBuildDrafts { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductBuildInvestment> ProductBuildInvestments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductBuildMaterial> ProductBuildMaterials { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProductBuildRouterLink> ProductBuildRouterLinks { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Router> Routers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RouterAction> RouterActions { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RouterDetail> RouterDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RouterOutsideDetail> RouterOutsideDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RouterProcess> RouterProcesses { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RouterProcessDetail> RouterProcessDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RouterType> RouterTypes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Company> Companies { get; set; }
        public virtual Company Company { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Customer> Customers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Item> Items { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ItemStatu> ItemStatus { get; set; }
        public virtual Location Location { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Location> Locations { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LocationDetail> LocationDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Vendor> Vendors { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Employee> Employee1 { get; set; }
        public virtual Employee Employee2 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ItemLocation> ItemLocations { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ItemLotBin> ItemLotBins { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ItemSerial> ItemSerials { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Machine> Machines { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MachineType> MachineTypes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MfgConsumable> MfgConsumables { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MfgConsumableType> MfgConsumableTypes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ScheduledWorkOrder> ScheduledWorkOrders { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StockMovement> StockMovements { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StockMovement> StockMovements1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StockMovementDetail> StockMovementDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TeamGroup> TeamGroups { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TeamGroupEmployeeDetail> TeamGroupEmployeeDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TeamGroupEmployeeDetail> TeamGroupEmployeeDetails1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TeamGroupMachineDetail> TeamGroupMachineDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ToolSet> ToolSets { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ToolSetDetail> ToolSetDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WorkCenter> WorkCenters { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WorkCenterGroup> WorkCenterGroups { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WorkCenterType> WorkCenterTypes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WorkOrder> WorkOrders { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WorkOrderDetail> WorkOrderDetails { get; set; }
    }
}