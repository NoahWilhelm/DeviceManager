export class Device {

  entry_Id: number;
  id: String;
  name: String;
  deviceTypeId: String;
  failsafe: boolean;
  tempMin: number;
  tempMax: number;
  installationPosition: String;
  insertInto19InchCabinet: boolean;
  motionEnable: boolean;
  siplusCatalog: boolean;
  simaticCatalog: boolean;
  rotationAxisNumber: number;
  positionAxisNumber: number;
  terminalElement: boolean | null;
  advancedEnvironmentalConditions: boolean | null;

}
