using System.ComponentModel;

namespace Microsoft.Halo.Core.DataContracts.Enums
{
	public enum EnemyClass
	{
		[Description("Any")]
		Any = 0x00,

		[Description("Infantry")]
		Infantry = 0x01,

		[Description("Leader")]
		Leader = 0x02,

		[Description("Hero")]
		Hero = 0x03,

		[Description("Specialist")]
		Specialist = 0x04,

		[Description("Light Vehicle")]
		LightVehicle = 0x05,

		[Description("Heavy Vehcile")]
		HeavyVehcile = 0x06,

		[Description("Giant Vehicle")]
		GiantVehicle = 0x07,

		[Description("Standard Vehicle")]
		StandardVehicle = 0x08
	}
}
