// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

import styled from '@emotion/styled';
import { StepWizardChildProps } from "react-step-wizard";
import { StepNavItemInfo } from '../model/StepNavItemInfo';
import { useWindowSize } from './UseWindowSize';

export function WizardNavBar(wizardProps: StepWizardChildProps, navSteps: StepNavItemInfo[]) {
    const navStepItems = navSteps.map((item: StepNavItemInfo, index: number) => {
        if (item.IsActive) {
            return <RunningStep color="#1890ff" key={index} >{item.Caption}</RunningStep>
        } else if (item.IsEnabled) {
            return <CompleteStep color={"#389e0d"} key={index} onClick={() => wizardProps.goToStep(item.TargetStep)}>{item.Caption}</CompleteStep>
        }
        else {
            return <NotStartStep color="#bfbfbf" key={index} >{item.Caption}</NotStartStep>
        }
    });

    const winSize = useWindowSize();

    return (<LeftPanel style={{ height: winSize.height - HeaderMenuHeight }}>
        <Wizard>
            <VLine />
            {navStepItems}
        </Wizard>
    </LeftPanel>);
}

export const LeftPanelWidth = 250;
// header height 50 + 10 padding
export const HeaderMenuHeight = 60;

export const LeftPanel = styled.div`
    float: left;
    width: ${LeftPanelWidth}px;
    z-index:999;
    border-right-color: #7565;
    border-style: none solid none  none ;
    border-width: 2px;
    padding-left: 5px;
    background-color: #f1f1f1;
    font-size:larger;
    font-weight: 500;
`;

export const RightPanel = styled.div`
    & {
        margin-Left: ${LeftPanelWidth + 10}px;
        height: 100%;
        z-index:999;
        padding-left: 10px;
    }
    &::after {
        clear: "both";
    }
`;

export const Wizard = styled.div`
    margin-left: 40px;
    position: relative;
`;

export const VLine = styled.div`
    width: 3px;
    background-color: #69c0ff;
    position: absolute;
    margin-left: -21px;
    margin-top: 24px;
    height: 380px;
    `;

export const CompleteStep = styled.div`
        padding-Top: 20px;
        position: relative;
        cursor: pointer;
        color: ${props => props.color};
        &:before {
            content: '✔';
            color: #092b00;
            display: block;
            width: 1.5em;
            height: 1.5em;
            text-align: center;
            border-radius: 50%;
            background-color: ${props => props.color};
            position: absolute;
            margin-left:-35px;
          }
    `;

export const RunningStep = styled.div`
    padding-Top: 20px;
    position: relative;
    color: ${props => props.color};
    &:before {
        content: '▶';
        color: #003a8c;
        display: block;
        width: 1.5em;
        height: 1.5em;
        text-align: center;
        border-radius: 50%;
        background-color: ${props => props.color};
        position: absolute;
        margin-left:-35px;
      }
`;

export const NotStartStep = styled.div`
    padding-Top: 20px;
    position: relative;
    color: ${props => props.color};
    &:before {
        content: '';
        display: block;
        width: 1.5em;
        height: 1.5em;
        text-align: center;
        border-radius: 50%;
        background-color: ${props => props.color};
        position: absolute;
        margin-left:-35px;
      }
`;