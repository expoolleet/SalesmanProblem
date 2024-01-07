import numpy as np

#Функция нахождения минимального элемента, исключая текущий элемент
def Min(lst,myindex):
    return min(x for idx, x in enumerate(lst) if idx != myindex)

#функция удаления нужной строки и столбцах
def Delete(matrix,index1,index2):
    del matrix[index1]
    for i in matrix:
        del i[index2]
    return matrix

#Функция вывода матрицы
def PrintMatrix(matrix):
    output = "\r\n"
    for i in range(len(matrix)):
        output += "{0}\r\n".format(matrix[i])
    return output + "\r\n"

#Алгоритм
def Main(ndarray):
    matrix = ndarray.tolist()
    n = len(matrix[0])
    H=0
    PathLenght=0
    Str=[]
    Stb=[]
    res=[]
    result=[]
    StartMatrix=[]
    stepsOutput = ""

    for i in range(n):
        Str.append(i)
        Stb.append(i)
	
    for i in range(n):StartMatrix.append(matrix[i].copy())

    for i in range(n): matrix[i][i]=float('inf')

    step = 1
    stepsOutput += "Исходная матрица расстояний:\r\n"
    stepsOutput += PrintMatrix(matrix)
    
    while True:
        stepsOutput += "\r\nШаг {0}. Редуцируем.\r\n\r\n".format(step)
        step += 1

        stepsOutput += "Вычитаем минимальный элемент в строках:\r\n"
        tempH = 0
        for i in range(len(matrix)):
            temp=min(matrix[i])
            H+=temp
            tempH+=temp
            stepsOutput += "Минимальный элемент в {0} строке = {1}\r\n".format(i+1, temp)
            for j in range(len(matrix)):
                matrix[i][j]-=temp
        stepsOutput += "Получаем матрицу:\r\n"
        stepsOutput += PrintMatrix(matrix)
        stepsOutput += "Вычитаем минимальный элемент в столбцах:\r\n"
        for i in range(len(matrix)):
            temp = min(row[i] for row in matrix)
            H+=temp
            tempH+=temp
            stepsOutput += "Минимальный элемент в {0} столбце = {1}\r\n".format(i+1, temp)
            for j in range(len(matrix)):
                matrix[j][i]-=temp
        stepsOutput += "Получаем матрицу:\r\n"
        stepsOutput += PrintMatrix(matrix)

        stepsOutput += "Сумма приведенных констант строк и стобцов: {0}\r\n".format(tempH)
        stepsOutput += "Оценка пути: {0}\r\n".format(H)

        NullMax=0
        index1=0
        index2=0
        tmp=0
        for i in range(len(matrix)):
            for j in range(len(matrix)):
                if matrix[i][j]==0:
                    tmp=Min(matrix[i],j)+Min((row[j] for row in matrix),i)
                    if tmp>=NullMax:
                        NullMax=tmp
                        index1=i
                        index2=j
        
        if NullMax != float('inf'):
            stepsOutput +="Оцениваем нулевые клетки и ищем нулевую клетку с максимальной оценкой\r\n"
            stepsOutput += "Нулевая клетка с максимальной оценкой {0} = ({1}, {2})\r\n".format(NullMax, index1, index2)

        res.append(Str[index1]+1)
        res.append(Stb[index2]+1)
	
        oldIndex1=Str[index1]
        oldIndex2=Stb[index2]
        if oldIndex2 in Str and oldIndex1 in Stb:
            NewIndex1=Str.index(oldIndex2)
            NewIndex2=Stb.index(oldIndex1)
            matrix[NewIndex1][NewIndex2]=float('inf')
        del Str[index1]
        del Stb[index2]
        matrix=Delete(matrix,index1,index2)

        if len(matrix)==1:break
        stepsOutput += "Удаляем строку {0} и столбец {1}\r\n".format(index1+1, index2+1)
        stepsOutput += "Получаем матрицу:\r\n"
        stepsOutput += PrintMatrix(matrix)

    for i in range(0,len(res)-1,2):
        if res.count(res[i])<2:
            result.append(res[i])
            result.append(res[i+1])
    for i in range(0,len(res)-1,2):
        for j in range(0,len(res)-1,2):
            if result[len(result)-1]==res[j]:
                result.append(res[j])
                result.append(res[j+1])
    stepsOutput += "\r\n----------------------------------\r\n"
    stepsOutput += "Полученный наикратчайший путь Коммивояжера: {0}\r\n".format(result) 

    for i in range(0,len(result)-1,2):
        if i==len(result)-2:
            PathLenght+=StartMatrix[result[i]-1][result[i+1]-1]
            PathLenght+=StartMatrix[result[i+1]-1][result[0]-1]
        else: PathLenght+=StartMatrix[result[i]-1][result[i+1]-1]
    stepsOutput += "Длина пути: {0}\r\n".format(PathLenght)
    
    return (result, PathLenght, stepsOutput)