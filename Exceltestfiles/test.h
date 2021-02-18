/******************************************************************************
Copyright (C)

File Name     : test.h
Version       : Initial Draft
Author        : 
Created       : 2021/02/18
Description   : 
History       : 
1.Date        : 2021/02/18
  Author      : 
  Modification: Created file
*******************************************************************************/
#ifndef __TEST_H__
#define __TEST_H__

/*----------------------------------------------------------------------------*/
/*include                                                                     */
/*----------------------------------------------------------------------------*/
#include "gk_type.h"

/*----------------------------------------------------------------------------*/
/*struct                                                                      */
/*----------------------------------------------------------------------------*/
typedef struct _TEST_S
{

    GK_U32  : 5;
    GK_U32 NAME2 : 1;
    GK_U32 : 26;

    GK_U32 NAME3 : 32;

    GK_U32 NAME4_5 : 32;

    GK_U32 NAME5 : 32;

    GK_U32 NAME6 : 32;

    GK_U32 NAME7_2_3_ : 32;

    GK_U32 NAME8 : 32;

    GK_U32 NAME9 : 16;
    GK_U32 NAME10 : 16;

    GK_U32 NAME11 : 2;
    GK_U32 NAME12 : 2;
    GK_U32 NAME13 : 28;

    GK_U32 NAME14 : 32;

    GK_U32 NAME15 : 2;
    GK_U32 NAME15 : 3;
    GK_U32 NAME15 : 5;
    GK_U32 NAME15 : 5;
    GK_U32  : 1;
    GK_U32 NAME16 : 5;
    GK_U32  : 4;
    GK_U32 NAME16 : 1;
    GK_U32 : 6;

    GK_U32 NAME17 : 32;

    GK_U32  : 1;
    GK_U32 NAME17 : 31;

    GK_U32  : 2;
    GK_U32 NAME17 : 30;

    GK_U32  : 3;
    GK_U32 NAME17 : 29;
} TEST_S;

#endif /*__TEST_H__*/
