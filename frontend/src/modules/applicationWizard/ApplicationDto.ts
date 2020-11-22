export interface DocumentContract {
  date: Date;
  name: string;
  addressDetails: AddressDetails;
  correspondenceAddressDetails: AddressDetails;
  phoneNumber: string;
  email: string;
  investorType: EInvestorType;
  plannedWorkAddressDetails: PlannedWorkAddressDetails;
  oldEnergyCharacteristics: EnergyCharacteristicsOfWork;
  plannedEnergyCharacteristics: EnergyCharacteristicsOfWork;
  plannedCompletionDate: Date;
  estimatedCost: number;
  bankDetails: BankDetails;
  canConnectToHeatingNetwork: boolean;
  canConnectToGasNetwork: boolean;
  yearOfInvestment: number;
  propertyOwnershipType: PropertyOwnershipType;
  dispositionLawDocuments: string;
  exectuionCompany: string;
  nip: string;
  isBenefitingDeMinimis: boolean;
  lawParticipants: LawParticipant[];
}

export interface AddressDetails {
  streetName: string;
  buildingNumber: string;
  city: string;
  postCode: string;
}

export interface PlannedWorkAddressDetails {
  propertyRegistrationNumber: string;
  district: string;
  isForCommercialUse: boolean;
  usableArea: number;
  commercialArea: number;
  commercialToUsableAreaRatio: number;
}

export interface LawParticipant {
  name: string;
  addressDetails: AddressDetails;
}

export interface BankDetails {
  name: string;
  number: string;
}
export interface EnergyCharacteristicsOfWork {
  type: HeatingType;
  power: number;
  age: number;
  consumptionPerYear: number;
}

export enum HeatingType {
  NetworkNaturalGas,
  LiquefiedNaturalGas,
  Biomass,
  Electricity,
  NetworkHeat,
}

export enum PropertyOwnershipType {
  Owner,
  CoOwner,
  PermanentManagement,
  RestrictionsPropertyLaw,
  Other,
  PerpetualUsufruct,
}

export enum EInvestorType {
  Undefined,
  PrivateIndividual,
  Company,
  Farmer,
  Fisherman,
}


