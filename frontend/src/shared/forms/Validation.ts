export class Validation {
  static onlyPositiveDigitsRegex = /^\+?(\d+(\.(\d+)?)?|\.\d+)$/;
  static biggerThanZeroRegex = /^[1-9][0-9]*$/;
}
