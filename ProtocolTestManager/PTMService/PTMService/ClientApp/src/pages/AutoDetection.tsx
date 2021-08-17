// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

import {
  Link,
  IIconProps,
  IButtonStyles,
  IconButton,
  getTheme,
  FontWeights,
  mergeStyleSets,
  DetailsList,
  Dropdown,
  IColumn,
  Label,
  Modal,
  PrimaryButton,
  Stack,
  TextField,
  TooltipDelay,
  TooltipHost
} from '@fluentui/react'
import { StepWizardChildProps, StepWizardProps } from 'react-step-wizard'
import { StepPanel } from '../components/StepPanel'
import { WizardNavBar } from '../components/WizardNavBar'
import { getNavSteps } from '../model/DefaultNavSteps'
import { AppState } from '../store/configureStore'
import { useDispatch, useSelector } from 'react-redux'
import { useWindowSize } from '../components/UseWindowSize'
import { LoadingPanel } from '../components/LoadingPanel'
import { Property } from '../model/Property'
import { useEffect, useState, CSSProperties, ReactElement } from 'react'
import { AutoDetectionDataSrv } from '../services/AutoDetection'
import { SelectionMode } from '@uifabric/experiments/lib/Utilities'
import { AutoDetectActions } from '../actions/AutoDetectionAction'
import { DetectionStatus } from '../model/AutoDetectionData'
import { useBoolean } from '@uifabric/react-hooks'

export function AutoDetection (props: StepWizardProps) {
  const wizardProps: StepWizardChildProps = props as StepWizardChildProps
  const autoDetectionStepsResult = useSelector((state: AppState) => state.autoDetection).detectionSteps?.Result
  const [isAutoDetectionWarningDialogOpen, { setTrue: showAutoDetectionWarningDialog, setFalse: hideAutoDetectionWarningDialog }] = useBoolean(false)
  const autoDetectionLog = useSelector((state: AppState) => state.autoDetection.log)
  const [isAutoDetectionLogDialogOpen, { setTrue: showAutoDetectionLogDialog, setFalse: hideAutoDetectionLogDialog }] = useBoolean(false)
  const prerequisite = useSelector((state: AppState) => state.autoDetection)
  const navSteps = getNavSteps(wizardProps)
  const wizard = WizardNavBar(wizardProps, navSteps)
  const dispatch = useDispatch()
  const autoDetection = useSelector((state: AppState) => state.autoDetection)
  const winSize = useWindowSize()
  const [detectingTimes, setDetectingTimes] = useState(-999)
  const [detecting, setDetecting] = useState(false)

  useEffect(() => {
    dispatch(AutoDetectionDataSrv.getAutoDetectionPrerequisite())
  }, [dispatch])

  useEffect(() => {
    dispatch(AutoDetectionDataSrv.getAutoDetectionSteps())
  }, [dispatch])

  useEffect(() => {
    if (detectingTimes === -999 || isAutoDetectShouldStop()) {
      if (autoDetectionStepsResult?.Status === DetectionStatus.Error) {
        showAutoDetectionWarningDialog()
      }
      setDetecting(false)
      return
    }

    const timer = setTimeout(() => {
      setDetectingTimes(detectingTimes - 1)
      dispatch(AutoDetectionDataSrv.getAutoDetectionSteps())
    }, 1000)

    return () => clearTimeout(timer)
  }, [detectingTimes])

  const onPreviousButtonClick = () => {
    wizardProps.previousStep()
  }

  const onPropertyValueChange = (updatedProperty: Property) => {
    dispatch(AutoDetectActions.updateAutoDetectionPrerequisiteAction(updatedProperty))
  }

  // This function is to determine if detection status is suitable for running.
  const isAutoDetectShouldStop = () => {
    const statusToStop = autoDetectionStepsResult?.Status === DetectionStatus.Finished ||
            autoDetectionStepsResult?.Status === DetectionStatus.Error ||
            autoDetectionStepsResult?.Status === DetectionStatus.NotStart

    // We should get steps for 3 times no matter the status.
    if (detectingTimes >= 98) {
      return false
    }

    return statusToStop
  }

  const onNextButtonClick = () => {
    dispatch(AutoDetectionDataSrv.applyDetectionResult())
    if (autoDetectionStepsResult?.Status === DetectionStatus.Finished) {
      dispatch(AutoDetectionDataSrv.applyDetectionResult(() => {
        // Next page
        wizardProps.nextStep()
      }))
    }
  }

  const onDetectButtonClick = () => {
    if (detecting) {
      // Cancel
      dispatch(AutoDetectionDataSrv.stopAutoDetection())
      setDetectingTimes(-999)
      setDetecting(false)
    } else {
      // Start detect
      dispatch(AutoDetectionDataSrv.startAutoDetection())
      setDetectingTimes(100)
      setDetecting(true)
    }
  }

  const isPreviousButtonDisabled = (): boolean => {
    if (autoDetectionStepsResult?.Status === DetectionStatus.InProgress) {
      return true
    } else {
      return false
    }
  }

  const isDetectButtonDisabled = (): boolean => {
    return false
  }

  const isNextButtonDisabled = (): boolean => {
    if (autoDetectionStepsResult?.Status === DetectionStatus.Finished) {
      return false
    }

    return true
  }

  const getDetectButtonText = (): string => {
    if (detecting) {
      return 'Cancel'
    } else {
      return 'Detect'
    }
  }

  const StepColumns = (): IColumn[] => {
    const onFailClick = async (): Promise<ReturnType<typeof dispatch>> => dispatch(AutoDetectionDataSrv.getAutoDetectionLog(showAutoDetectionLogDialog))

    const getStyle = (status: string): CSSProperties => {
      if (status === 'Failed') {
        return { paddingLeft: 5, color: 'red' }
      } else if (status === 'Finished') {
        return { paddingLeft: 5, color: 'green' }
      } else {
        return { paddingLeft: 5 }
      }
    }

    const DetectingContent = (item: Property, index: number | undefined): ReactElement => {
      return (
                <Label>
                    <div style={{ paddingLeft: 5 }} >{item.Name}</div>
                </Label>
      )
    }

    const DetectingStatus = (item: any): ReactElement => {
      return (
                <Label>
                    <div style={ getStyle(item.Status) } >
                      {
                        ((status: string) => {
                          if (status === 'Failed') {
                            return (<Link
                                      underline
                                      style={getStyle(status)}
                                      onClick={onFailClick} >
                                      {status}
                                    </Link>)
                          } else {
                            return (<div style={getStyle(status)}>{status}</div>)
                          }
                        })(item.Status)
                      }
                    </div>
                </Label>
      )
    }

    return [{
      key: 'DetectingContent',
      name: 'DetectingContent',
      fieldName: 'DetectingContent',
      minWidth: 240,
      isRowHeader: true,
      isResizable: true,
      onRender: DetectingContent
    },
    {
      key: 'DetectingStatus',
      name: 'DetectingStatus',
      fieldName: 'DetectingStatus',
      minWidth: 480,
      isResizable: true,
      isPadded: true,
      onRender: DetectingStatus
    }]
  }

  const getListColumns = (props: { onRenderName: (prop: Property, index: number) => JSX.Element, onRenderValue: (prop: Property) => JSX.Element }): IColumn[] => {
    return [{
      key: 'Name',
      name: 'Name',
      fieldName: 'Name',
      minWidth: 240,
      isRowHeader: true,
      isResizable: true,
      onRender: (item: Property, index: number | undefined) => props.onRenderName(item, index!)
    },
    {
      key: 'Value',
      name: 'Value',
      fieldName: 'Value',
      minWidth: 480,
      isResizable: true,
      isPadded: true,
      onRender: (item: Property) => props.onRenderValue(item)
    }]
  }

  const listColumns = getListColumns({
    onRenderName: (item: Property, index: number) => {
      const latestProperty = prerequisite.prerequisite?.Properties[index]
      if (latestProperty?.Value === item.Value) {
        return (
                    <Label>
                        <div style={{ paddingLeft: 5 }}>{item.Name}</div>
                    </Label>
        )
      } else {
        return (
                    <Label style={{ backgroundSize: '120', backgroundColor: '#004578', color: 'white' }}>
                        <div style={{ paddingLeft: 5 }}>{item.Name}*</div>
                    </Label>
        )
      }
    },
    onRenderValue: (item: Property) => item.Choices?.length && item.Choices?.length > 1 ? RenderChoosableProperty(item)! : RenderCommonProperty(item)
  })

  function RenderChoosableProperty (property: Property) {
    if (property.Choices === undefined) {
      return
    }

    const dropdownOptions = property.Choices.map(choice => {
      return {
        key: choice.toLowerCase(),
        text: choice
      }
    })

    return (
            <TooltipHost
                style={{ alignSelf: 'center' }}
                key={prerequisite.prerequisite?.Title + property.Key + property.Name}
                content={property.Description}
                delay={TooltipDelay.zero}>
                <Stack horizontal tokens={{ childrenGap: 10 }}>
                    <Dropdown
                        style={{ alignSelf: 'center', minWidth: 360 }}
                        placeholder='Select an option'
                        defaultSelectedKey={property.Value?.toLowerCase()}
                        options={dropdownOptions}
                        onChange={(_, newValue, __) => onPropertyValueChange({ ...property, Value: newValue?.text! })}
                    />
                </Stack>
            </TooltipHost>
    )
  }

  function RenderCommonProperty (property: Property) {
    return (
            <TooltipHost
                style={{ alignSelf: 'center' }}
                key={prerequisite.prerequisite?.Title + property.Key + property.Name}
                content={property.Description}
                delay={TooltipDelay.zero}>
                <Stack horizontal tokens={{ childrenGap: 10 }}>
                    <TextField
                        style={{ alignSelf: 'stretch', minWidth: 360 }}
                        value={property.Value}
                        onChange={(_, newValue) => onPropertyValueChange({ ...property, Value: newValue! })}
                    />
                </Stack>
            </TooltipHost>
    )
  }

  return (
        <div>
            <StepPanel leftNav={wizard} isLoading={autoDetection.isPrerequisiteLoading || autoDetection.isDetectionStepsLoading} errorMsg={''} >
                <Stack style={{ paddingLeft: 10 }}>
                    <Stack>
                        {prerequisite.prerequisite?.Summary}
                    </Stack>

                    <div style={{ paddingLeft: 30, width: winSize.width, height: winSize.height / 2 - 180, overflowY: 'auto' }}>
                        {
                            prerequisite.isPrerequisiteLoading
                              ? <LoadingPanel />
                              : <div>
                                    <Stack horizontal style={{ paddingTop: 20 }} horizontalAlign='start' tokens={{ childrenGap: 10 }}>
                                        <div style={{ borderLeft: '2px solid #bae7ff', minHeight: 200 }}>
                                            <DetailsList
                                                columns={listColumns}
                                                items={((prerequisite.prerequisite?.Properties) != null) ? prerequisite.prerequisite?.Properties : []}
                                                compact
                                                selectionMode={SelectionMode.none}
                                                isHeaderVisible={false}
                                            />
                                        </div>
                                    </Stack>
                                </div>

                        }
                    </div>
                    <div style={{ paddingLeft: 30, width: winSize.width, height: winSize.height / 2, overflowY: 'auto' }}>
                        {
                            prerequisite.isDetectionStepsLoading
                              ? <LoadingPanel />
                              : <div>
                                    <Stack horizontal style={{ paddingTop: 20 }} horizontalAlign='start' tokens={{ childrenGap: 10 }}>
                                        <div style={{ borderLeft: '2px solid #bae7ff', minHeight: 200 }}>
                                            <DetailsList
                                                columns={StepColumns()}
                                                items={((prerequisite.detectionSteps?.DetectingItems) != null) ? prerequisite.detectionSteps?.DetectingItems : []}
                                                compact
                                                selectionMode={SelectionMode.none}
                                                isHeaderVisible={false}
                                            />
                                        </div>
                                    </Stack>
                                </div>

                        }
                    </div>
                    <div className='buttonPanel'>
                        <Stack horizontal horizontalAlign="end" tokens={{ childrenGap: 10 }} >
                            <PrimaryButton text="Previous" onClick={onPreviousButtonClick} disabled={isPreviousButtonDisabled()} />
                            <PrimaryButton text="Next" onClick={onNextButtonClick} disabled={isNextButtonDisabled()} />
                            <PrimaryButton text={getDetectButtonText()} onClick={onDetectButtonClick} disabled={isDetectButtonDisabled()} />
                        </Stack>
                    </div>
                </Stack>
            </StepPanel>

            <Modal
                isOpen={isAutoDetectionWarningDialogOpen}
                containerClassName={contentStyles.container}
            >
              <div className={contentStyles.header}>
                <span>Warning</span>
                <IconButton
                  styles={iconButtonStyles}
                  iconProps={cancelIcon}
                  onClick={hideAutoDetectionWarningDialog}
                />
              </div>
              <div className={contentStyles.body}>
                  <TextField multiline readOnly autoAdjustHeight defaultValue={autoDetectionStepsResult?.Exception} />
              </div>
            </Modal>

            <Modal
                isOpen={isAutoDetectionLogDialogOpen}
                containerClassName={contentStyles.container}
            >
              <div className={contentStyles.header}>
                <span>Log</span>
                <IconButton
                  styles={iconButtonStyles}
                  iconProps={cancelIcon}
                  onClick={hideAutoDetectionLogDialog}
                />
              </div>
              <div className={contentStyles.body}>
                  <TextField multiline readOnly autoAdjustHeight defaultValue={autoDetectionLog} />
              </div>
            </Modal>
        </div>
  )
};

const theme = getTheme()
const contentStyles = mergeStyleSets({
  container: {
    display: 'flex',
    flexFlow: 'column nowrap',
    alignItems: 'stretch',
    minWidth: '50%'
  },
  header: [
    theme.fonts.xxLarge,
    {
      flex: '1 1 auto',
      borderTop: `4px solid ${theme.palette.themePrimary}`,
      color: theme.palette.neutralPrimary,
      display: 'flex',
      alignItems: 'center',
      fontWeight: FontWeights.semibold,
      padding: '12px 12px 14px 24px'
    }
  ],
  body: {
    flex: '4 4 auto',
    padding: '0 24px 24px 24px',
    overflowY: 'hidden',
    selectors: {
      p: { margin: '14px 0' },
      'p:first-child': { marginTop: 0 },
      'p:last-child': { marginBottom: 0 }
    }
  }
})

const cancelIcon: IIconProps = { iconName: 'Cancel' }

const iconButtonStyles: Partial<IButtonStyles> = {
  root: {
    color: theme.palette.neutralPrimary,
    marginLeft: 'auto',
    marginTop: '4px',
    marginRight: '2px'
  },
  rootHovered: {
    color: theme.palette.neutralDark
  }
}
