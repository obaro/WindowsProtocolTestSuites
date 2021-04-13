// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

import {
    GET_TESTSUITES_REQUEST,
    GET_TESTSUITES_SUCCESS,
    GET_TESTSUITES_FAILURE,
    TestSuitesActionTypes
} from '../actions/TestSuitesActions';

import {
    GET_TESTSUITE_CONFIGURATIONS_REQUEST,
    GET_TESTSUITE_CONFIGURATIONS_SUCCESS,
    GET_TESTSUITE_CONFIGURATIONS_FAILURE,
    TestSuiteConfigurationActionTypes
} from '../actions/TestSuiteConfigurationAction';

import {
    ABORT_RUNREQUEST_REQUEST,
    ABORT_RUNREQUEST_SUCCESS,
    ABORT_RUNREQUEST_FAILURE,
    SelectedTestCasesActionTypes
} from '../actions/SelectedTestCasesActions';

import {
    LIST_TESTRESULTS_REQUEST,
    LIST_TESTRESULTS_SUCCESS,
    LIST_TESTRESULTS_FAILURE,
    SET_PAGENUMBER,
    SET_SELECTEDTESTRESULT,
    CLEAR_SELECTEDTESTRESULT,
    GET_TESTRESULTDETAIL_REQUEST,
    GET_TESTRESULTDETAIL_SUCCESS,
    GET_TESTRESULTDETAIL_FAILURE,
    TestResultsActionTypes
} from '../actions/TestResultsActions';
import { Configuration } from '../model/Configuration';
import { TestResult, TestResultOverview, TestResultSummary } from '../model/TestResult';
import { TestSuite } from '../model/TestSuite';

export interface TestResultsState {
    isLoading: boolean;
    isPosting: boolean;
    errorMsg?: string;
    allTestSuites: TestSuite[];
    allConfigurations: Configuration[];
    pageNumber: number;
    pageCount: number;
    currentPageResults: TestResultOverview[];
    pageSize: 15;
    selectedTestResultId: number | undefined;
    selectedTestResultSummary: TestResultSummary | undefined;
    selectedTestResult: TestResult | undefined;
}

const initialTestResultsState: TestResultsState = {
    isLoading: false,
    isPosting: false,
    errorMsg: undefined,
    allTestSuites: [],
    allConfigurations: [],
    pageNumber: 0,
    pageCount: 0,
    currentPageResults: [],
    pageSize: 15,
    selectedTestResultId: undefined,
    selectedTestResultSummary: undefined,
    selectedTestResult: undefined
};

const getUpdatedConfigurations = (state: TestResultsState, newConfigurations: Configuration[]) => {
    if (state.allConfigurations.length === 0) {
        return newConfigurations;
    }

    const updatedConf = state.allConfigurations.map((item) => {
        const updatedList = newConfigurations.filter((i) => i.Id === item.Id);
        if (updatedList.length > 0) {
            return updatedList[0];
        }
        else {
            return item;
        }
    });

    const newConf = newConfigurations.filter((item) => updatedConf.reduce((res: boolean, curr) => res && curr.Id !== item.Id, true));

    return [...updatedConf, ...newConf]
};

export const getTestResultsReducer = (state = initialTestResultsState, action: TestResultsActionTypes | TestSuitesActionTypes | TestSuiteConfigurationActionTypes | SelectedTestCasesActionTypes): TestResultsState => {
    switch (action.type) {
        case GET_TESTSUITES_REQUEST:
            return {
                ...state,
                isPosting: true,
                errorMsg: undefined
            };

        case GET_TESTSUITES_SUCCESS:
            return {
                ...state,
                isPosting: false,
                allTestSuites: action.payload
            };

        case GET_TESTSUITES_FAILURE:
            return {
                ...state,
                isPosting: false,
                errorMsg: action.errorMsg
            };

        case GET_TESTSUITE_CONFIGURATIONS_REQUEST:
            return {
                ...state,
                isPosting: true,
                errorMsg: undefined
            }

        case GET_TESTSUITE_CONFIGURATIONS_SUCCESS:
            return {
                ...state,
                isPosting: false,
                allConfigurations: getUpdatedConfigurations(state, action.payload)
            };

        case GET_TESTSUITE_CONFIGURATIONS_FAILURE:
            return {
                ...state,
                isPosting: false,
                errorMsg: action.errorMsg
            };

        case ABORT_RUNREQUEST_REQUEST:
            return {
                ...state,
                isLoading: true,
                errorMsg: undefined
            };

        case ABORT_RUNREQUEST_SUCCESS:
            return {
                ...state,
                isLoading: false
            };

        case ABORT_RUNREQUEST_FAILURE:
            return {
                ...state,
                isLoading: false,
                errorMsg: action.errorMsg
            };

        case LIST_TESTRESULTS_REQUEST:
            return {
                ...state,
                isPosting: true,
                errorMsg: undefined
            };

        case LIST_TESTRESULTS_SUCCESS:
            return {
                ...state,
                isPosting: false,
                pageNumber: state.pageNumber > action.payload.PageCount - 1 ? action.payload.PageCount - 1 : state.pageNumber,
                pageCount: action.payload.PageCount,
                currentPageResults: action.payload.TestResults
            };

        case LIST_TESTRESULTS_FAILURE:
            return {
                ...state,
                isPosting: false,
                errorMsg: action.errorMsg
            };

        case SET_PAGENUMBER:
            return {
                ...state,
                pageNumber: action.payload
            };

        case SET_SELECTEDTESTRESULT:
            return {
                ...state,
                selectedTestResultId: action.testResultId,
                selectedTestResultSummary: action.summary
            };

        case CLEAR_SELECTEDTESTRESULT:
            return {
                ...state,
                selectedTestResultId: undefined,
                selectedTestResultSummary: undefined,
                selectedTestResult: undefined
            };

        case GET_TESTRESULTDETAIL_REQUEST:
            return {
                ...state,
                isPosting: true,
                errorMsg: undefined,
            };

        case GET_TESTRESULTDETAIL_SUCCESS:
            return {
                ...state,
                isPosting: false,
                selectedTestResult: action.payload
            };

        case GET_TESTRESULTDETAIL_FAILURE:
            return {
                ...state,
                isPosting: false,
                errorMsg: action.errorMsg
            };

        default:
            return state;
    }
};