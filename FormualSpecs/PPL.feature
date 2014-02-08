Feature: PPL
	Update the TelesProfiles database with load profile coefficients.
	The inputs will an arbitrary data range, and weather forecast ID.
	The output will be a set of coefficients for the given date range,
	written to specified table(s)


Scenario: Calculate coefficient for single interval
	Given the following coefficients and constants:
	| HIGH_1  | HIGH_2  | HIGH_3  | HIGH_4 | COEFF_1 | COEFF_2 | COEFF_3 | COEFF_4 | CONSTANT |
	| 50.4741 | 64.5280 | 77.3043 | 99999  | -0.0204 | -0.0028 | 0.0055  | 0.0297  | 2.5810   |

	And the temperature is 50 degF
	When the coefficient request is made
	Then the result should be 1.5625
