// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

import { Configuration } from "../model/Configuration";

// define action consts
export const GET_TESTSUITE_CONFIGURATIONS_REQUEST = 'CONFIGURATION/GET_TESTSUITE_CONFIGURATIONS_REQUEST';
export const GET_TESTSUITE_CONFIGURATIONS_SUCCESS = 'CONFIGURATION/GET_TESTSUITE_CONFIGURATIONS_SUCCESS';
export const GET_TESTSUITE_CONFIGURATIONS_FAILURE = 'CONFIGURATION/GET_TESTSUITE_CONFIGURATIONS_FAILURE';

export const SET_SELECTED_TESTSUITE = 'CONFIGURATION/SET_SELECTED_TESTSUITE';
export const SET_SEARCHTEXT = 'CONFIGURATION/SET_SEARCHTEXT'

// define action types
interface GetTSConfigurationsActionRequestType { type: typeof GET_TESTSUITE_CONFIGURATIONS_REQUEST; }
interface GetTSConfigurationsActionSuccessType { type: typeof GET_TESTSUITE_CONFIGURATIONS_SUCCESS; payload: Configuration[]; }
interface GetTSConfigurationsActionFailureType { type: typeof GET_TESTSUITE_CONFIGURATIONS_FAILURE; errorMsg: string; }
interface SetTSConfigurationActionType { type: typeof SET_SELECTED_TESTSUITE; selectedConfiguration: Configuration }
interface SetSearchTextActionType { type: typeof SET_SEARCHTEXT; searchText: string }

export type TestSuiteConfigurationActionTypes = GetTSConfigurationsActionRequestType
    | GetTSConfigurationsActionSuccessType
    | GetTSConfigurationsActionFailureType
    | SetTSConfigurationActionType
    | SetSearchTextActionType;

// define actions
export const ConfigurationActions = {
    getConfigurationAction_Request: (): TestSuiteConfigurationActionTypes => {
        return {
            type: GET_TESTSUITE_CONFIGURATIONS_REQUEST
        }
    },
    getConfigurationAction_Success: (configurations: Configuration[]): TestSuiteConfigurationActionTypes => {
        return {
            type: GET_TESTSUITE_CONFIGURATIONS_SUCCESS,
            payload: configurations
        }
    },
    getConfigurationAction_Failure: (error: string): TestSuiteConfigurationActionTypes => {
        return {
            type: GET_TESTSUITE_CONFIGURATIONS_FAILURE,
            errorMsg: error
        }
    },
    setSelectedConfigurationAction: (selectedConfiguration: Configuration): TestSuiteConfigurationActionTypes => {
        return {
            type: SET_SELECTED_TESTSUITE,
            selectedConfiguration: selectedConfiguration
        }
    },
    setSearchTextAction: (filter: string): TestSuiteConfigurationActionTypes => {
        return {
            type: SET_SEARCHTEXT,
            searchText: filter
        }
    },
}