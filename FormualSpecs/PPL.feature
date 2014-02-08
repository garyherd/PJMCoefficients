Feature: PPL
	Update the TelesProfiles database with load profile coefficients.
	The inputs will an arbitrary date range, and a weather forecast ID.
	The output will be a set of coefficients for the given date range,
	written to specified table(s)


Scenario Outline: Calculate coefficient for single interval
	Given the following coefficients and constants:
	| Field               | Value   |
	| HIGH_1              | 50.4741 |
	| HIGH_2              | 64.5280 |
	| HIGH_3              | 77.3043 |
	| HIGH_4              | 99999   |
	| COEFF_1             | -0.0204 |
	| COEFF_2             | -0.0028 |
	| COEFF_3             | 0.0055  |
	| COEFF_4             | 0.0297  |
	| REGRESSION_CONSTANT | 2.5810  |

	And the temperature is <temperature> degF
	When the coefficient request is made
	Then the result should be <coefficient>

	Examples: 
	| temperature | coefficient |
	| 50          | 1.561       |
	| 60          | 1.5247      |
	| 70          | 1.5421      |
	| 80          | 1.6623      |


