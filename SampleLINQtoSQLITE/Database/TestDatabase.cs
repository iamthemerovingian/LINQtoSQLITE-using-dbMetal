// 
//  ____  _     __  __      _        _ 
// |  _ \| |__ |  \/  | ___| |_ __ _| |
// | | | | '_ \| |\/| |/ _ \ __/ _` | |
// | |_| | |_) | |  | |  __/ || (_| | |
// |____/|_.__/|_|  |_|\___|\__\__,_|_|
//
// Auto-generated from main on 2016-11-30 13:47:11Z.
// Please visit http://code.google.com/p/dblinq2007/ for more information.
//
using System;
using System.ComponentModel;
using System.Data;
#if MONO_STRICT
	using System.Data.Linq;
#else   // MONO_STRICT
	using DbLinq.Data.Linq;
	using DbLinq.Vendor;
#endif  // MONO_STRICT
	using System.Data.Linq.Mapping;
using System.Diagnostics;


public partial class TestDatabaseContext : DataContext
{
	
	#region Extensibility Method Declarations
		partial void OnCreated();
		#endregion
	
	
	public TestDatabaseContext(string connectionString) : 
			base(connectionString)
	{
		this.OnCreated();
	}
	
	public TestDatabaseContext(string connection, MappingSource mappingSource) : 
			base(connection, mappingSource)
	{
		this.OnCreated();
	}
	
	public TestDatabaseContext(IDbConnection connection, MappingSource mappingSource) : 
			base(connection, mappingSource)
	{
		this.OnCreated();
	}
	
	public Table<Company> Company
	{
		get
		{
			return this.GetTable<Company>();
		}
	}
	
	public Table<Manager> Manager
	{
		get
		{
			return this.GetTable<Manager>();
		}
	}
	
	public Table<Employee> Employee
	{
		get
		{
			return this.GetTable<Employee>();
		}
	}
	
	public Table<Person> Person
	{
		get
		{
			return this.GetTable<Person>();
		}
	}
}

#region Start MONO_STRICT
#if MONO_STRICT

public partial class TestDatabaseContext
{
	
	public TestDatabaseContext(IDbConnection connection) : 
			base(connection)
	{
		this.OnCreated();
	}
}
#region End MONO_STRICT
	#endregion
#else     // MONO_STRICT

public partial class TestDatabaseContext
{
	
	public TestDatabaseContext(IDbConnection connection) : 
			base(connection, new DbLinq.Sqlite.SqliteVendor())
	{
		this.OnCreated();
	}
	
	public TestDatabaseContext(IDbConnection connection, IVendor sqlDialect) : 
			base(connection, sqlDialect)
	{
		this.OnCreated();
	}
	
	public TestDatabaseContext(IDbConnection connection, MappingSource mappingSource, IVendor sqlDialect) : 
			base(connection, mappingSource, sqlDialect)
	{
		this.OnCreated();
	}
}
#region End Not MONO_STRICT
	#endregion
#endif     // MONO_STRICT
#endregion

[Table(Name="main.Company")]
public partial class Company : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
{
	
	private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs("");
	
	private int _companyID;
	
	private int _employeeID;
	
	private int _managerID;
	
	private EntityRef<Manager> _manager = new EntityRef<Manager>();
	
	private EntityRef<Employee> _employee = new EntityRef<Employee>();
	
	#region Extensibility Method Declarations
		partial void OnCreated();
		
		partial void OnCompanyIDChanged();
		
		partial void OnCompanyIDChanging(int value);
		
		partial void OnEmployeeIDChanged();
		
		partial void OnEmployeeIDChanging(int value);
		
		partial void OnManagerIDChanged();
		
		partial void OnManagerIDChanging(int value);
		#endregion
	
	
	public Company()
	{
		this.OnCreated();
	}
	
	[Column(Storage="_companyID", Name="CompanyID", DbType="INTEGER", IsPrimaryKey=true, IsDbGenerated=true, AutoSync=AutoSync.Never, CanBeNull=false)]
	[DebuggerNonUserCode()]
	public int CompanyID
	{
		get
		{
			return this._companyID;
		}
		set
		{
			if ((_companyID != value))
			{
				this.OnCompanyIDChanging(value);
				this.SendPropertyChanging();
				this._companyID = value;
				this.SendPropertyChanged("CompanyID");
				this.OnCompanyIDChanged();
			}
		}
	}
	
	[Column(Storage="_employeeID", Name="EmployeeID", DbType="INTEGER", AutoSync=AutoSync.Never, CanBeNull=false)]
	[DebuggerNonUserCode()]
	public int EmployeeID
	{
		get
		{
			return this._employeeID;
		}
		set
		{
			if ((_employeeID != value))
			{
				if (_employee.HasLoadedOrAssignedValue)
				{
					throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
				}
				this.OnEmployeeIDChanging(value);
				this.SendPropertyChanging();
				this._employeeID = value;
				this.SendPropertyChanged("EmployeeID");
				this.OnEmployeeIDChanged();
			}
		}
	}
	
	[Column(Storage="_managerID", Name="ManagerID", DbType="INTEGER", AutoSync=AutoSync.Never, CanBeNull=false)]
	[DebuggerNonUserCode()]
	public int ManagerID
	{
		get
		{
			return this._managerID;
		}
		set
		{
			if ((_managerID != value))
			{
				if (_manager.HasLoadedOrAssignedValue)
				{
					throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
				}
				this.OnManagerIDChanging(value);
				this.SendPropertyChanging();
				this._managerID = value;
				this.SendPropertyChanged("ManagerID");
				this.OnManagerIDChanged();
			}
		}
	}
	
	#region Parents
	[Association(Storage="_manager", OtherKey="ManagerID", ThisKey="ManagerID", Name="fk_Company_0", IsForeignKey=true)]
	[DebuggerNonUserCode()]
	public Manager Manager
	{
		get
		{
			return this._manager.Entity;
		}
		set
		{
			if (((this._manager.Entity == value) 
						== false))
			{
				if ((this._manager.Entity != null))
				{
					Manager previousManager = this._manager.Entity;
					this._manager.Entity = null;
					previousManager.Company.Remove(this);
				}
				this._manager.Entity = value;
				if ((value != null))
				{
					value.Company.Add(this);
					_managerID = value.ManagerID;
				}
				else
				{
					_managerID = default(int);
				}
			}
		}
	}
	
	[Association(Storage="_employee", OtherKey="EmployeeID", ThisKey="EmployeeID", Name="fk_Company_1", IsForeignKey=true)]
	[DebuggerNonUserCode()]
	public Employee Employee
	{
		get
		{
			return this._employee.Entity;
		}
		set
		{
			if (((this._employee.Entity == value) 
						== false))
			{
				if ((this._employee.Entity != null))
				{
					Employee previousEmployee = this._employee.Entity;
					this._employee.Entity = null;
					previousEmployee.Company.Remove(this);
				}
				this._employee.Entity = value;
				if ((value != null))
				{
					value.Company.Add(this);
					_employeeID = value.EmployeeID;
				}
				else
				{
					_employeeID = default(int);
				}
			}
		}
	}
	#endregion
	
	public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;
	
	public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
	
	protected virtual void SendPropertyChanging()
	{
		System.ComponentModel.PropertyChangingEventHandler h = this.PropertyChanging;
		if ((h != null))
		{
			h(this, emptyChangingEventArgs);
		}
	}
	
	protected virtual void SendPropertyChanged(string propertyName)
	{
		System.ComponentModel.PropertyChangedEventHandler h = this.PropertyChanged;
		if ((h != null))
		{
			h(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
		}
	}
}

[Table(Name="main.Manager")]
public partial class Manager
{
	
	private int _managerID;
	
	private string _managerRank;
	
	private EntitySet<Company> _company;
	
	private EntityRef<Person> _person = new EntityRef<Person>();
	
	#region Extensibility Method Declarations
		partial void OnCreated();
		
		partial void OnManagerIDChanged();
		
		partial void OnManagerIDChanging(int value);
		
		partial void OnManagerRankChanged();
		
		partial void OnManagerRankChanging(string value);
		#endregion
	
	
	public Manager()
	{
		_company = new EntitySet<Company>(new Action<Company>(this.Company_Attach), new Action<Company>(this.Company_Detach));
		this.OnCreated();
	}
	
	[Column(Storage="_managerID", Name="Manager_ID", DbType="INTEGER", AutoSync=AutoSync.Never, CanBeNull=false)]
	[DebuggerNonUserCode()]
	public int ManagerID
	{
		get
		{
			return this._managerID;
		}
		set
		{
			if ((_managerID != value))
			{
				this.OnManagerIDChanging(value);
				this._managerID = value;
				this.OnManagerIDChanged();
			}
		}
	}
	
	[Column(Storage="_managerRank", Name="Manager_Rank", DbType="VARCHAR", AutoSync=AutoSync.Never, CanBeNull=false)]
	[DebuggerNonUserCode()]
	public string ManagerRank
	{
		get
		{
			return this._managerRank;
		}
		set
		{
			if (((_managerRank == value) 
						== false))
			{
				this.OnManagerRankChanging(value);
				this._managerRank = value;
				this.OnManagerRankChanged();
			}
		}
	}
	
	#region Children
	[Association(Storage="_company", OtherKey="ManagerID", ThisKey="ManagerID", Name="fk_Company_0")]
	[DebuggerNonUserCode()]
	public EntitySet<Company> Company
	{
		get
		{
			return this._company;
		}
		set
		{
			this._company = value;
		}
	}
	#endregion
	
	#region Parents
	[Association(Storage="_person", OtherKey="PersonID", ThisKey="ManagerID", Name="fk_Manager_0", IsForeignKey=true)]
	[DebuggerNonUserCode()]
	public Person Person
	{
		get
		{
			return this._person.Entity;
		}
		set
		{
			if (((this._person.Entity == value) 
						== false))
			{
				if ((this._person.Entity != null))
				{
					Person previousPerson = this._person.Entity;
					this._person.Entity = null;
					previousPerson.Manager.Remove(this);
				}
				this._person.Entity = value;
				if ((value != null))
				{
					value.Manager.Add(this);
					_managerID = value.PersonID;
				}
				else
				{
					_managerID = default(int);
				}
			}
		}
	}
	#endregion
	
	#region Attachment handlers
	private void Company_Attach(Company entity)
	{
		entity.Manager = this;
	}
	
	private void Company_Detach(Company entity)
	{
		entity.Manager = null;
	}
	#endregion
}

[Table(Name="main.employee")]
public partial class Employee
{
	
	private int _employeeID;
	
	private string _employeeRank;
	
	private int _employeeHouseID;
	
	private EntitySet<Company> _company;
	
	private EntityRef<Person> _person = new EntityRef<Person>();
	
	private EntityRef<Person> _person1 = new EntityRef<Person>();
	
	#region Extensibility Method Declarations
		partial void OnCreated();
		
		partial void OnEmployeeIDChanged();
		
		partial void OnEmployeeIDChanging(int value);
		
		partial void OnEmployeeRankChanged();
		
		partial void OnEmployeeRankChanging(string value);
		
		partial void OnEmployeeHouseIDChanged();
		
		partial void OnEmployeeHouseIDChanging(int value);
		#endregion
	
	
	public Employee()
	{
		_company = new EntitySet<Company>(new Action<Company>(this.Company_Attach), new Action<Company>(this.Company_Detach));
		this.OnCreated();
	}
	
	[Column(Storage="_employeeID", Name="employee_id", DbType="INTEGER", AutoSync=AutoSync.Never, CanBeNull=false)]
	[DebuggerNonUserCode()]
	public int EmployeeID
	{
		get
		{
			return this._employeeID;
		}
		set
		{
			if ((_employeeID != value))
			{
				this.OnEmployeeIDChanging(value);
				this._employeeID = value;
				this.OnEmployeeIDChanged();
			}
		}
	}
	
	[Column(Storage="_employeeRank", Name="employee_rank", DbType="VARCHAR", AutoSync=AutoSync.Never, CanBeNull=false)]
	[DebuggerNonUserCode()]
	public string EmployeeRank
	{
		get
		{
			return this._employeeRank;
		}
		set
		{
			if (((_employeeRank == value) 
						== false))
			{
				this.OnEmployeeRankChanging(value);
				this._employeeRank = value;
				this.OnEmployeeRankChanged();
			}
		}
	}
	
	[Column(Storage="_employeeHouseID", Name="employee_house_id", DbType="INTEGER", AutoSync=AutoSync.Never, CanBeNull=false)]
	[DebuggerNonUserCode()]
	public int EmployeeHouseID
	{
		get
		{
			return this._employeeHouseID;
		}
		set
		{
			if ((_employeeHouseID != value))
			{
				this.OnEmployeeHouseIDChanging(value);
				this._employeeHouseID = value;
				this.OnEmployeeHouseIDChanged();
			}
		}
	}
	
	#region Children
	[Association(Storage="_company", OtherKey="EmployeeID", ThisKey="EmployeeID", Name="fk_Company_1")]
	[DebuggerNonUserCode()]
	public EntitySet<Company> Company
	{
		get
		{
			return this._company;
		}
		set
		{
			this._company = value;
		}
	}
	#endregion
	
	#region Parents
	[Association(Storage="_person", OtherKey="PersonHouseID", ThisKey="EmployeeHouseID", Name="fk_employee_0", IsForeignKey=true)]
	[DebuggerNonUserCode()]
	public Person Person
	{
		get
		{
			return this._person.Entity;
		}
		set
		{
			if (((this._person.Entity == value) 
						== false))
			{
				if ((this._person.Entity != null))
				{
					Person previousPerson = this._person.Entity;
					this._person.Entity = null;
					previousPerson.Employee.Remove(this);
				}
				this._person.Entity = value;
				if ((value != null))
				{
					value.Employee.Add(this);
					_employeeHouseID = value.PersonHouseID;
				}
				else
				{
					_employeeHouseID = default(int);
				}
			}
		}
	}
	
	[Association(Storage="_person1", OtherKey="PersonID", ThisKey="EmployeeID", Name="fk_employee_1", IsForeignKey=true)]
	[DebuggerNonUserCode()]
	public Person Person1
	{
		get
		{
			return this._person1.Entity;
		}
		set
		{
			if (((this._person1.Entity == value) 
						== false))
			{
				if ((this._person1.Entity != null))
				{
					Person previousPerson = this._person1.Entity;
					this._person1.Entity = null;
					previousPerson.Employee1.Remove(this);
				}
				this._person1.Entity = value;
				if ((value != null))
				{
					value.Employee1.Add(this);
					_employeeID = value.PersonID;
				}
				else
				{
					_employeeID = default(int);
				}
			}
		}
	}
	#endregion
	
	#region Attachment handlers
	private void Company_Attach(Company entity)
	{
		entity.Employee = this;
	}
	
	private void Company_Detach(Company entity)
	{
		entity.Employee = null;
	}
	#endregion
}

[Table(Name="main.person")]
public partial class Person : System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
{
	
	private static System.ComponentModel.PropertyChangingEventArgs emptyChangingEventArgs = new System.ComponentModel.PropertyChangingEventArgs("");
	
	private int _personID;
	
	private string _personName;
	
	private int _personHouseID;
	
	private EntitySet<Manager> _manager;
	
	private EntitySet<Employee> _employee;
	
	private EntitySet<Employee> _employee1;
	
	#region Extensibility Method Declarations
		partial void OnCreated();
		
		partial void OnPersonIDChanged();
		
		partial void OnPersonIDChanging(int value);
		
		partial void OnPersonNameChanged();
		
		partial void OnPersonNameChanging(string value);
		
		partial void OnPersonHouseIDChanged();
		
		partial void OnPersonHouseIDChanging(int value);
		#endregion
	
	
	public Person()
	{
		_manager = new EntitySet<Manager>(new Action<Manager>(this.Manager_Attach), new Action<Manager>(this.Manager_Detach));
		_employee = new EntitySet<Employee>(new Action<Employee>(this.Employee_Attach), new Action<Employee>(this.Employee_Detach));
		_employee1 = new EntitySet<Employee>(new Action<Employee>(this.Employee1_Attach), new Action<Employee>(this.Employee1_Detach));
		this.OnCreated();
	}
	
	[Column(Storage="_personID", Name="person_id", DbType="INTEGER", IsPrimaryKey=true, IsDbGenerated=true, AutoSync=AutoSync.Never, CanBeNull=false)]
	[DebuggerNonUserCode()]
	public int PersonID
	{
		get
		{
			return this._personID;
		}
		set
		{
			if ((_personID != value))
			{
				this.OnPersonIDChanging(value);
				this.SendPropertyChanging();
				this._personID = value;
				this.SendPropertyChanged("PersonID");
				this.OnPersonIDChanged();
			}
		}
	}
	
	[Column(Storage="_personName", Name="person_name", DbType="VARCHAR", AutoSync=AutoSync.Never, CanBeNull=false)]
	[DebuggerNonUserCode()]
	public string PersonName
	{
		get
		{
			return this._personName;
		}
		set
		{
			if (((_personName == value) 
						== false))
			{
				this.OnPersonNameChanging(value);
				this.SendPropertyChanging();
				this._personName = value;
				this.SendPropertyChanged("PersonName");
				this.OnPersonNameChanged();
			}
		}
	}
	
	[Column(Storage="_personHouseID", Name="person_HouseID", DbType="INTEGER", AutoSync=AutoSync.Never, CanBeNull=false)]
	[DebuggerNonUserCode()]
	public int PersonHouseID
	{
		get
		{
			return this._personHouseID;
		}
		set
		{
			if ((_personHouseID != value))
			{
				this.OnPersonHouseIDChanging(value);
				this.SendPropertyChanging();
				this._personHouseID = value;
				this.SendPropertyChanged("PersonHouseID");
				this.OnPersonHouseIDChanged();
			}
		}
	}
	
	#region Children
	[Association(Storage="_manager", OtherKey="ManagerID", ThisKey="PersonID", Name="fk_Manager_0")]
	[DebuggerNonUserCode()]
	public EntitySet<Manager> Manager
	{
		get
		{
			return this._manager;
		}
		set
		{
			this._manager = value;
		}
	}
	
	[Association(Storage="_employee", OtherKey="EmployeeHouseID", ThisKey="PersonHouseID", Name="fk_employee_0")]
	[DebuggerNonUserCode()]
	public EntitySet<Employee> Employee
	{
		get
		{
			return this._employee;
		}
		set
		{
			this._employee = value;
		}
	}
	
	[Association(Storage="_employee1", OtherKey="EmployeeID", ThisKey="PersonID", Name="fk_employee_1")]
	[DebuggerNonUserCode()]
	public EntitySet<Employee> Employee1
	{
		get
		{
			return this._employee1;
		}
		set
		{
			this._employee1 = value;
		}
	}
	#endregion
	
	public event System.ComponentModel.PropertyChangingEventHandler PropertyChanging;
	
	public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
	
	protected virtual void SendPropertyChanging()
	{
		System.ComponentModel.PropertyChangingEventHandler h = this.PropertyChanging;
		if ((h != null))
		{
			h(this, emptyChangingEventArgs);
		}
	}
	
	protected virtual void SendPropertyChanged(string propertyName)
	{
		System.ComponentModel.PropertyChangedEventHandler h = this.PropertyChanged;
		if ((h != null))
		{
			h(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
		}
	}
	
	#region Attachment handlers
	private void Manager_Attach(Manager entity)
	{
		this.SendPropertyChanging();
		entity.Person = this;
	}
	
	private void Manager_Detach(Manager entity)
	{
		this.SendPropertyChanging();
		entity.Person = null;
	}
	
	private void Employee_Attach(Employee entity)
	{
		this.SendPropertyChanging();
		entity.Person = this;
	}
	
	private void Employee_Detach(Employee entity)
	{
		this.SendPropertyChanging();
		entity.Person = null;
	}
	
	private void Employee1_Attach(Employee entity)
	{
		this.SendPropertyChanging();
		entity.Person1 = this;
	}
	
	private void Employee1_Detach(Employee entity)
	{
		this.SendPropertyChanging();
		entity.Person1 = null;
	}
	#endregion
}
