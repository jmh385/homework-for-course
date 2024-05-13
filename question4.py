import matplotlib.pyplot as plt
import numpy as np


def pearson_correlation_coefficient(x: np.array, y: np.array) -> float:
    """

    :param x: data set 1
    :param y: data set 2
    :return: The pearson correlation coefficient of the 2 datasets
    """

    # vectorised solution for faster processing
    avg1: float = np.average(x)
    avg2: float = np.average(y)

    x -= avg1
    y -= avg2

    cov_xy: float = x @ y
    square_standard_deviation_x = x @ x
    square_standard_deviation_y = y @ y

    return cov_xy / np.sqrt(square_standard_deviation_x*square_standard_deviation_y)


data: list = []
num: float = float(input("enter num, -1 to stop"))
while num != -1:
    data.append(num)
    num = float(input("enter num, -1 to stop"))

data_array: np.array = np.array(data)
x_axis: np.array = np.arange(1, len(data_array)+1, dtype=float)

avg: float = np.average(data_array)
print(f"data average: {avg}")

print(f"count of positive numbers: {sum(1 for n in data_array if n > 0)}")

print(f"sorted data: {sorted(data_array)}")

print(f"Pearson correlation coefficient: {pearson_correlation_coefficient(data_array, x_axis)}")

plt.plot(x_axis, data_array, 'bx-')
plt.show()

