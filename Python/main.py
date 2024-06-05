import csv
import matplotlib.pyplot as plt
from simplification.cutil import (
    simplify_coords,
    simplify_coords_idx,
    simplify_coords_vw,
    simplify_coords_vw_idx,
    simplify_coords_vwp,
)

# Function to read float values from a CSV file

valuesFromTest = [
    [3600, 200],
    [7200, 299],
    [10800, 398],
    [14400, 495]]

def read_float_values_from_csv(csv_filename, countValues = 2000):
    float_values = []
    with open(csv_filename, 'r') as csvfile:
        csv_reader = csv.reader(csvfile)
        next(csv_reader)  # Skip header row
        for index, row in enumerate(csv_reader):
            # Assuming the second column contains float values
            float_values.append(float(row[0]))
            
            if index == countValues:
                break
    return float_values


# Define CSV filename
#csv_filename = "generatedValuesSin.csv"

# Read float values from CSV file
#float_values = read_float_values_from_csv(csv_filename)

#valuesToSymplify = [[index * 3600, value] for index, value in enumerate(float_values)]

#print("RDP algorithm:")
#print(simplify_coords(valuesFromTest, 0))
#print("Visvalingam-Whyatt algorithm:")
#simplified = [i[1] for i in simplify_coords(valuesToSymplify, 0.15)]

#print(f"count of values: {len(simplified)}")

# Plot the float values
#plt.plot(simplified)
#plt.title('Float Values Plot')
#plt.xlabel('Index')
#plt.ylabel('Float Value')
#plt.grid(True)
#plt.show()

print(simplify_coords_vw_idx([
    [5.0, 2.0],
    [3.0, 8.0],
    [6.0, 20.0],
    [7.0, 25.0],
    [10.0, 10.0]], 30.0))
