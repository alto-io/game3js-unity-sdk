mergeInto(LibraryManager.library, {
  SendEvent: function(outplayEvent)
  {
    ReactUnityWebGL.SendEvent(UTF8ToString(outplayEvent));
  },

  SendNumber: function(number) {
    ReactUnityWebGL.SendNumber(number);
  },
  SendString: function(message) {
    ReactUnityWebGL.SendString(UTF8ToString(message));
  },

  SendScore: function(number) {
    ReactUnityWebGL.SendScore(number);
  },

});
