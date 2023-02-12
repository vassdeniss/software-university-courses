(function extendString() {
  String.prototype.ensureStart = function (str) {
    if (this.startsWith(str)) {
      return this.toString();
    }

    return `${str}${this}`;
  };

  String.prototype.ensureEnd = function (str) {
    if (this.endsWith(str)) {
      return this.toString();
    }

    return `${this}${str}`;
  };

  String.prototype.isEmpty = function () {
    return this.toString() === '';
  };

  String.prototype.truncate = function (n) {
    if (n < 4) {
      return '.'.repeat(n);
    }

    if (this.toString().length <= n) {
      return this.toString();
    }

    if (this.toString().length > n) {
      const space = this.toString()
        .slice(0, n - 2)
        .lastIndexOf(' ');
      if (space === -1) {
        return this.toString().slice(0, n - 3) + '...';
      } else {
        return this.toString().slice(0, space) + '...';
      }
    }
  };

  String.format = function (str, ...rest) {
    rest.forEach((text, i) => (str = str.replace(`{${i}}`, text)));
    return str;
  };
})();

let str = 'my string';
str = str.ensureStart('my');
str = str.ensureStart('hello ');
str = str.truncate(16);
str = str.truncate(14);
str = str.truncate(8);
str = str.truncate(4);
str = str.truncate(2);
str = String.format('The {0} {1} fox', 'quick', 'brown');
str = String.format('jumps {0} {1}', 'dog');
