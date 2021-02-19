# ExcelConvert
该工具可以将excel工作表转化为c头文件  
  
使用方法  
	1、根据需求选择或不选择‘使用默认文件名’‘使用配置文件’‘显示Debug信息’  
	2、点击 选择输入文件 按钮选择待转化的excel文件  
	3、点击 选择输出文件 按钮选择输出的头文件的全路径及文件名，如果选择了‘使用默认文件名’则是点击 选择输出路径 按钮选择输出的头文件的路径  
	4、如果选择了‘使用配置文件’则需点击 选择配置文件 按钮选择配置文件(.txt)  
		配置文件格式要求：  
		sheet name: testsheet  
		module name: module  
		start row: 3  
		end row: 10  
		...  
		其中冒号后面的内容按需修改，注意冒号后有一个空格  
		每四行代表一个工作表的配置  
	5、设置参数：  
		physical register col  寄存器偏移值所在列  
		logical register col  寄存器名所在列  
		bit position col  寄存器位域范围所在列  
		r/w col  寄存器读写权限所在列  
		start row  开始行  
		end row  结束行  
		module name 模块名，与结构体命名相关，当选择‘使用默认文件名’时也与文件名相关   
		sheet name  待转化的工作表名  
	6、点击 开始 按钮，等待转化完成  
  
头文件内容包含：  
	文件头注释  
		/******************************************************************************  
		Copyright (C)  

		File Name     : testsheet.h  
		Version       : Initial Draft  
		Author        :   
		Created       : 2021/02/19  
		Description   :   
		History       :   
		1.Date        : 2021/02/19  
		  Author      :   
		  Modification: Created file  
		*******************************************************************************/  
	防止重编译的宏  
		#ifndef __TESTSHEET_H__  
		#define __TESTSHEET_H__  
		...  
		#endif /*__TESTSHEET_H__*/  
	注释头  
		/*----------------------------------------------------------------------------*/  
		/*struct                                                                      */  
		/*----------------------------------------------------------------------------*/  
	头文件引用  
		#include "type.h"  
	结构体定义  
		typedef struct _TESTSHEET_S  
		{  
		...  
		} TESTSHEET_S;  
