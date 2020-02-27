"use strict";

(function () {
  var target = EventTarget.prototype;
  var functionName = 'addEventListener';
  var func = target[functionName];
  var symbolHidden = Symbol('hidden');

  function hidden(instance) {
    if (instance[symbolHidden] === undefined) {
      var area = {};
      instance[symbolHidden] = area;
      return area;
    }

    return instance[symbolHidden];
  }

  function listenersFrom(instance) {
    var area = hidden(instance);

    if (!area.listeners) {
      area.listeners = [];
    }

    return area.listeners;
  }

  target[functionName] = function (type, listener) {
    var listeners = listenersFrom(this);
    listeners.push({
      type: type,
      listener: listener
    });
    func.apply(this, [type, listener]);
  };

  target['removeEventListeners'] = function (targetType) {
    var self = this;
    var listeners = listenersFrom(this);
    var removed = [];
    listeners.forEach(function (item) {
      var type = item.type;
      var listener = item.listener;

      if (type === targetType) {
        self.removeEventListener(type, listener);
      }
    });
  };
})();