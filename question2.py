def pythagorean_triplet_by_sum(sum: int) -> None:
    # a + b + c = sum - by the given of the question
    # sum - c = a + b
    # a + b > c - because a, b, c are sides in a triangle
    # sum - c > c
    # sum > 2c
    # sum/2 > c
    #
    # c > a, c > b
    # 2c > a + b
    # a + b = sum-c
    # 2c > sum - c
    # 3c > sum => c > sum/3
    for c in range(sum//3+1, sum//2):
        target = sum-c
        a = 1
        b = target - 1
        while a < b:
            if a**2 + b**2 == c**2:
                print(a, b, c)

            #  increment insures that a + b + c = sum
            a += 1
            b -= 1
