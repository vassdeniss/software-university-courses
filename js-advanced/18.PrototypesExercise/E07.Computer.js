function createComputerHierarchy() {
  class Electronic {
    constructor(manufacturer) {
      if (new.target === Electronic) {
        throw new Error('Electronic class is abstract!');
      }

      this.manufacturer = manufacturer;
    }
  }

  class Keyboard extends Electronic {
    constructor(manufacturer, responseTime) {
      super(manufacturer);

      this.responseTime = responseTime;
    }
  }

  class Monitor extends Electronic {
    constructor(manufacturer, width, height) {
      super(manufacturer);

      this.width = width;
      this.height = height;
    }
  }

  class Battery extends Electronic {
    constructor(manufacturer, expectedLife) {
      super(manufacturer);

      this.expectedLife = expectedLife;
    }
  }

  class Computer extends Electronic {
    constructor(manufacturer, processorSpeed, ram, hardDiskSpace) {
      super(manufacturer);

      if (new.target === Computer) {
        throw new Error('Computer class is abstract!');
      }

      this.processorSpeed = processorSpeed;
      this.ram = ram;
      this.hardDiskSpace = hardDiskSpace;
    }
  }

  class Laptop extends Computer {
    constructor(
      manufacturer,
      processorSpeed,
      ram,
      hardDiskSpace,
      weight,
      color,
      battery
    ) {
      super(manufacturer, processorSpeed, ram, hardDiskSpace);

      this.weight = weight;
      this.color = color;
      this.battery = battery;
    }

    get battery() {
      return this._battery;
    }

    set battery(battery) {
      if (!(battery instanceof Battery)) {
        throw new TypeError('Value must be of type Battery!');
      }

      this._battery = battery;
    }
  }

  class Desktop extends Computer {
    constructor(
      manufacturer,
      processorSpeed,
      ram,
      hardDiskSpace,
      keyboard,
      monitor
    ) {
      super(manufacturer, processorSpeed, ram, hardDiskSpace);

      this.keyboard = keyboard;
      this.monitor = monitor;
    }

    get keyboard() {
      return this._keyboard;
    }

    set keyboard(keyboard) {
      if (!(keyboard instanceof Keyboard)) {
        throw new TypeError('Value must be of type Keyboard!');
      }

      this._keyboard = keyboard;
    }

    get monitor() {
      return this._monitor;
    }

    set monitor(monitor) {
      if (!(monitor instanceof Monitor)) {
        throw new TypeError('Value must be of type Monitor!');
      }

      this._monitor = monitor;
    }
  }

  return {
    Electronic,
    Battery,
    Keyboard,
    Monitor,
    Computer,
    Laptop,
    Desktop,
  };
}
