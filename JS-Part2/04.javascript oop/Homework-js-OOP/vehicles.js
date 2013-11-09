var typeOfVehicle = (function() {

	Function.prototype.inherits = function(parent) {
		this.prototype = new parent();
		this.prototype.constructor = parent;
	}	

	Function.prototype.extends = function(parent) {
		for (var i = 1; i < arguments.length; i+=1) {
			var name=arguments[i];
			this.prototype[name] = parent.prototype[name];
		}
		return this;
	}

	//declaring some enumeration
	var AfterburnerSwitch = Object.freeze({
        "ACTIVATED": 1,
        "DEACTIVATED": 2
    });

	var SpinDirection = Object.freeze({
        "CLOCKWISE": 1,
        "COUNTERCLOCKWISE": 2
    });

    var AmphibianMode = Object.freeze({
        "LAND": 1,
        "WATER": 2
    });

	//representation of Propulsion Unit
	function PropulsionUnit() {
	}

	//acceleration of all propulsion units of all types of vehicles
	PropulsionUnit.prototype.getAcceleration = function() {
		throw new Error("Function not implemented for Propulsion Unit");
	}

	function Wheel(radius) {
		this.radius=radius;
	}

	Wheel.inherits(PropulsionUnit);

	//calculate acceleration for one wheel - return integer number
	Wheel.prototype.getAcceleration = function() {
		return parseInt(2 * Math.PI * this.radius);
	}

	function PropellingNozzle(power, afterburnerSwitch) {
		this.power=power;
		this.afterburnerSwitch=afterburnerSwitch;
	}

	PropellingNozzle.inherits(PropulsionUnit);

	//deactivate afterberner - acceleration is equal to power of one propelling nozzle
	//activated - afterburner is on it should produce double acceleration
	PropellingNozzle.prototype.getAcceleration = function() {
		if (this.afterburnerSwitch===AfterburnerSwitch.ACTIVATED) {
			return 2*this.power;
		} else{
			return this.power;
		};
	}

	// Propeller inherits from PropulsionUnit
	function Propeller(numberOfFins,spineDirection) {
		this.numberOfFins=numberOfFins;
		this.spineDirection=spineDirection;
	}
	Propeller.inherits(PropulsionUnit);

	//acceleration is equal to the number of fins on one propeller
	Propeller.prototype.getAcceleration = function () {
		if (this.spineDirection === SpinDirection.CLOCKWISE) {
			return this.numberOfFins;
		} else{
			return -this.numberOfFins;
		}
	}

	//from task -> All vehicles should have speed and propulsion units
	//create vehicle abstract object
	function Vehicle(speed,propulsionUnits) {
		this.speed=speed;
		this.propulsionUnits = propulsionUnits;
	}

	//create accelerate method for all types of vehicles
	//to update speed by summing it with the acceleration of their propulsion units 
	Vehicle.prototype.accelerate = function () {
		for (var i = 0, len=this.propulsionUnits.length; i < len; i++)	{
			this.speed +=this.propulsionUnits[i].getAcceleration();
		}
	}

	//instance object land vehicle with speed and wheels
	function LandVehicle(speed,wheels) {
		Vehicle.apply(this,arguments);

	}
	LandVehicle.inherits(Vehicle);

	//instance object air vehicle with speed and propelling nozzles
	function AirVehicle(speed,propellingNozzles) {
		Vehicle.apply(this,arguments);
	}

	AirVehicle.inherits(Vehicle);

	//instance object water vehicle with speed and propellers
	function WaterVehicle(speed,propellers) {
		Vehicle.apply(this,arguments);
	}

	WaterVehicle.inherits(Vehicle);

	//method for air vehicle to switch afterburner on or off
	AirVehicle.prototype.switchingAfterburner = function(afterburnerSwitch) {
		for (var i = 0, len= this.propulsionUnits.length; i < len; i++) {
			if (this.propulsionUnits[i] instanceof PropellingNozzle ) {
				this.propulsionUnits[i].afterburnerSwitch=afterburnerSwitch;
			};
		}
	}

	WaterVehicle.prototype.changePropellerSpineDirection = function (spineDirection) {
		for (var i = 0, len= this.propulsionUnits.length; i < len; i++) {
			if (this.propulsionUnits[i] instanceof Propeller ) {
				this.propulsionUnits[i].spineDirection = spineDirection;
			};
		}
	}
	
	//create object amphibian
	function Amphibian(speed, propellers,wheels,mode) {
		var propulsionUnits=[];
		for (var i = 0; i < propellers.length; i++) {
			propulsionUnits.push(propellers[i]);
		};
		for (var i = 0; i < wheels.length; i++) {
			propulsionUnits.push(wheels[i]);
		};

		Vehicle.call(this,speed,propulsionUnits);
		this.mode=mode;
	}

	//use multiply inheritance with extends
	Amphibian.inherits(Vehicle);
	Amphibian.extends(WaterVehicle,"changePropellerSpineDirection");

	Amphibian.prototype.accelerate = function() {
		if (this.mode===AmphibianMode.LAND) {
			for (var i = 0, len= this.propulsionUnits.length; i < len; i++) {
				if (this.propulsionUnits[i] instanceof Wheel ) {
					this.speed+=this.propulsionUnits[i].getAcceleration();
				};
			}
		} else{
			for (var i = 0, len= this.propulsionUnits.length; i < len; i++) {
				if (this.propulsionUnits[i] instanceof Propeller ) {
					this.speed+=this.propulsionUnits[i].getAcceleration();
				};
			}
		};
	}

	 return {
        AfterburnerSwitch: AfterburnerSwitch,
        SpinDirection: SpinDirection,
        AmphibianMode: AmphibianMode,
        Wheel: Wheel,
        PropellingNozzle: PropellingNozzle,
        Propeller: Propeller,
        LandVehicle: LandVehicle,
        AirVehicle: AirVehicle,
        WaterVehicle: WaterVehicle,
        Amphibian: Amphibian
    };
}());
