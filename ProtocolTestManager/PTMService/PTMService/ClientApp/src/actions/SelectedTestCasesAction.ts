// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

// define action consts
export const GET_ALLTESTCASES_REQUEST = 'SELECTEDTESTCASES/GET_ALLTESTCASES_REQUEST'
export const GET_ALLTESTCASES_SUCCESS = 'SELECTEDTESTCASES/GET_ALLTESTCASES_SUCCESS'
export const GET_ALLTESTCASES_FAILURE = 'SELECTEDTESTCASES/GET_ALLTESTCASES_FAILURE'

export const CREATE_RUNREQUEST_REQUEST = 'SELECTEDTESTCASES/CREATE_RUNREQUEST_REQUEST'
export const CREATE_RUNREQUEST_SUCCESS = 'SELECTEDTESTCASES/CREATE_RUNREQUEST_SUCCESS'
export const CREATE_RUNREQUEST_FAILURE = 'SELECTEDTESTCASES/CREATE_RUNREQUEST_FAILURE'

export const ABORT_RUNREQUEST_REQUEST = 'SELECTEDTESTCASES/ABORT_RUNREQUEST_REQUEST'
export const ABORT_RUNREQUEST_SUCCESS = 'SELECTEDTESTCASES/ABORT_RUNREQUEST_SUCCESS'
export const ABORT_RUNREQUEST_FAILURE = 'SELECTEDTESTCASES/ABORT_RUNREQUEST_FAILURE'

// define action types
interface GetAllTestCasesActionRequestType { type: typeof GET_ALLTESTCASES_REQUEST }
interface GetAllTestCasesActionSuccessType { type: typeof GET_ALLTESTCASES_SUCCESS, payload: string[] }
interface GetAllTestCasesActionFailureType { type: typeof GET_ALLTESTCASES_FAILURE, errorMsg: string }

interface CreateRunRequestActionRequestType { type: typeof CREATE_RUNREQUEST_REQUEST }
interface CreateRunRequestActionSuccessType { type: typeof CREATE_RUNREQUEST_SUCCESS, payload: number }
interface CreateRunRequestActionFailureType { type: typeof CREATE_RUNREQUEST_FAILURE, errorMsg: string }

interface AbortRunRequestActionRequestType { type: typeof ABORT_RUNREQUEST_REQUEST, payload: number }
interface AbortRunRequestActionSuccessType { type: typeof ABORT_RUNREQUEST_SUCCESS }
interface AbortRunRequestActionFailureType { type: typeof ABORT_RUNREQUEST_FAILURE, errorMsg: string }

export type SelectedTestCasesActionTypes =
    GetAllTestCasesActionRequestType |
    GetAllTestCasesActionSuccessType |
    GetAllTestCasesActionFailureType |
    CreateRunRequestActionRequestType |
    CreateRunRequestActionSuccessType |
    CreateRunRequestActionFailureType |
    AbortRunRequestActionRequestType |
    AbortRunRequestActionSuccessType |
    AbortRunRequestActionFailureType

// define actions
export const SelectedTestCasesActions = {
  getAllTestCasesAction_Request: (): SelectedTestCasesActionTypes => {
    return {
      type: GET_ALLTESTCASES_REQUEST
    }
  },
  getAllTestCasesAction_Success: (testCases: string[]): SelectedTestCasesActionTypes => {
    return {
      type: GET_ALLTESTCASES_SUCCESS,
      payload: testCases
    }
  },
  getAllTestCasesAction_Failure: (error: string): SelectedTestCasesActionTypes => {
    return {
      type: GET_ALLTESTCASES_FAILURE,
      errorMsg: error
    }
  },
  createRunRequestAction_Request: (): SelectedTestCasesActionTypes => {
    return {
      type: CREATE_RUNREQUEST_REQUEST
    }
  },
  createRunRequestAction_Success: (testResultId: number): SelectedTestCasesActionTypes => {
    return {
      type: CREATE_RUNREQUEST_SUCCESS,
      payload: testResultId
    }
  },
  createRunRequestAction_Failure: (error: string): SelectedTestCasesActionTypes => {
    return {
      type: CREATE_RUNREQUEST_FAILURE,
      errorMsg: error
    }
  },
  abortRunRequestAction_Request: (testResultId: number): SelectedTestCasesActionTypes => {
    return {
      type: ABORT_RUNREQUEST_REQUEST,
      payload: testResultId
    }
  },
  abortRunRequestAction_Success: (): SelectedTestCasesActionTypes => {
    return {
      type: ABORT_RUNREQUEST_SUCCESS
    }
  },
  abortRunRequestAction_Failure: (error: string): SelectedTestCasesActionTypes => {
    return {
      type: ABORT_RUNREQUEST_FAILURE,
      errorMsg: error
    }
  }
}
