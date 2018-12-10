# Assignment (Required)

Create a .NET Web API that takes ZIP-code as a parameter, then outputs city name, current temperature, time zone, and general elevation at the location with a user-friendly message. For example, “At the location $CITY_NAME, the temperature is $TEMPERATURE, the timezone is $TIMEZONE, and the elevation is $ELEVATION”. Include documentation with any necessary build instructions and be prepared to discuss your approach.

1.  Use the [Open WeatherMap current weather API](https://www.google.com/url?q=https://openweathermap.org/api&sa=D&ust=1544412232002000) to retrieve the current temperature and city name. You will be required to sign up for a [free API key](https://www.google.com/url?q=https://openweathermap.org/appid&sa=D&ust=1544412232002000).
2.  Use the [Google Time Zone API](https://www.google.com/url?q=https://developers.google.com/maps/documentation/timezone/start?hl%3Den_US&sa=D&ust=1544412232002000) to get the current timezone for a location. You will again need to register a “project” and sign up for a [free API key](https://www.google.com/url?q=https://developers.google.com/maps/documentation/timezone/get-api-key&sa=D&ust=1544412232003000) \* with Google.
3.  Use the [Google Elevation API](https://www.google.com/url?q=https://developers.google.com/maps/documentation/elevation/start&sa=D&ust=1544412232003000) to retrieve elevation data for a location.

\* Note that a credit card will [soon be required](https://www.google.com/url?q=https://cloud.google.com/maps-platform/user-guide/?_ga%3D2.15384382.901596364.1527268232-1880365229.1525881538&sa=D&ust=1544412232004000) to register for an API key with Google (though the first 40k API calls are [still free](https://www.google.com/url?q=https://cloud.google.com/maps-platform/pricing/sheet/&sa=D&ust=1544412232004000)). If this is a blocker, please contact *reducted* for a temporary API key.

# Full-Stack/Front End - Stretch goal (Optional)

In addition to the required assignment above, write a modern JS-based SPA front-end that allows a user to input a zipcode, then output the response-message to the page, preferably utilizing the tool you created above.
