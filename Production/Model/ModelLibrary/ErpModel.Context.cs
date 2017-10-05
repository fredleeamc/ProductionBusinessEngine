﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ModelEntities : DbContext
    {
        public ModelEntities()
            : base("name=ModelEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Bom> Boms { get; set; }
        public virtual DbSet<BomDetail> BomDetails { get; set; }
        public virtual DbSet<BomItemType> BomItemTypes { get; set; }
        public virtual DbSet<BomMfgConsumable> BomMfgConsumables { get; set; }
        public virtual DbSet<BomOtherCostDetail> BomOtherCostDetails { get; set; }
        public virtual DbSet<EngineeringChangeStatu> EngineeringChangeStatus { get; set; }
        public virtual DbSet<EngineeringPhase> EngineeringPhases { get; set; }
        public virtual DbSet<FamilyRouter> FamilyRouters { get; set; }
        public virtual DbSet<FamilyRouterLink> FamilyRouterLinks { get; set; }
        public virtual DbSet<ManufacturedComponent> ManufacturedComponents { get; set; }
        public virtual DbSet<ManufacturedSubComponent> ManufacturedSubComponents { get; set; }
        public virtual DbSet<ProductBuild> ProductBuilds { get; set; }
        public virtual DbSet<ProductBuildBomLink> ProductBuildBomLinks { get; set; }
        public virtual DbSet<ProductBuildDetail> ProductBuildDetails { get; set; }
        public virtual DbSet<ProductBuildDevelopmentLabor> ProductBuildDevelopmentLabors { get; set; }
        public virtual DbSet<ProductBuildDraft> ProductBuildDrafts { get; set; }
        public virtual DbSet<ProductBuildInvestment> ProductBuildInvestments { get; set; }
        public virtual DbSet<ProductBuildMaterial> ProductBuildMaterials { get; set; }
        public virtual DbSet<ProductBuildRouterLink> ProductBuildRouterLinks { get; set; }
        public virtual DbSet<Router> Routers { get; set; }
        public virtual DbSet<RouterAction> RouterActions { get; set; }
        public virtual DbSet<RouterDetail> RouterDetails { get; set; }
        public virtual DbSet<RouterOutsideDetail> RouterOutsideDetails { get; set; }
        public virtual DbSet<RouterProcess> RouterProcesses { get; set; }
        public virtual DbSet<RouterProcessDetail> RouterProcessDetails { get; set; }
        public virtual DbSet<RouterType> RouterTypes { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<ItemStatu> ItemStatus { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<LocationDetail> LocationDetails { get; set; }
        public virtual DbSet<Vendor> Vendors { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<ItemLocation> ItemLocations { get; set; }
        public virtual DbSet<ItemLotBin> ItemLotBins { get; set; }
        public virtual DbSet<ItemSerial> ItemSerials { get; set; }
        public virtual DbSet<Machine> Machines { get; set; }
        public virtual DbSet<MachineType> MachineTypes { get; set; }
        public virtual DbSet<StockMovement> StockMovements { get; set; }
        public virtual DbSet<StockMovementDetail> StockMovementDetails { get; set; }
        public virtual DbSet<MfgConsumable> MfgConsumables { get; set; }
        public virtual DbSet<MfgConsumableType> MfgConsumableTypes { get; set; }
        public virtual DbSet<ScheduledWorkOrder> ScheduledWorkOrders { get; set; }
        public virtual DbSet<TeamGroup> TeamGroups { get; set; }
        public virtual DbSet<TeamGroupEmployeeDetail> TeamGroupEmployeeDetails { get; set; }
        public virtual DbSet<TeamGroupMachineDetail> TeamGroupMachineDetails { get; set; }
        public virtual DbSet<ToolSet> ToolSets { get; set; }
        public virtual DbSet<ToolSetDetail> ToolSetDetails { get; set; }
        public virtual DbSet<WorkCenter> WorkCenters { get; set; }
        public virtual DbSet<WorkCenterGroup> WorkCenterGroups { get; set; }
        public virtual DbSet<WorkCenterType> WorkCenterTypes { get; set; }
        public virtual DbSet<WorkOrder> WorkOrders { get; set; }
        public virtual DbSet<WorkOrderDetail> WorkOrderDetails { get; set; }
        public virtual DbSet<RouterDetailsLink> RouterDetailsLinks { get; set; }
        public virtual DbSet<ConversionUnit> ConversionUnits { get; set; }
        public virtual DbSet<Currency> Currencies { get; set; }
        public virtual DbSet<Unit> Units { get; set; }
        public virtual DbSet<CurrencyExchange> CurrencyExchanges { get; set; }
        public virtual DbSet<JobPriority> JobPriorities { get; set; }
        public virtual DbSet<PrimeLoad> PrimeLoads { get; set; }
    }
}
