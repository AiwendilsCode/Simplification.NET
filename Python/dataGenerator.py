import csv
import random
import math
import json

# Function to generate a random integer between a specified range


def generate_random_integer(min_value, max_value):
    return random.randint(min_value, max_value)

# Function to generate a random float between a specified range


def generate_random_float(min_value, max_value):
    return random.uniform(min_value, max_value)

def generateSin(input):
    return math.sin(input)

# Define parameters
num_values = 1500
filename = "generatedValuesSin"

# Generate values
values = []
for i in range(num_values):
    value = generateSin(math.radians(i))

    values.append([i * 3600, value])
    

# Save values to CSV file
filename += ".csv"
with open(filename, 'w', newline='') as csvfile:
    csv_writer = csv.writer(csvfile)
    csv_writer.writerow(["value"])
    csv_writer.writerows([[i[1]] for i in values])

#json_array = json.dumps(values)
#filename += ".json"
#with open(filename, 'w', newline='') as jsonFile:
    #jsonFile.write(json_array)

print(f"Values have been generated and saved to '{filename}'.")